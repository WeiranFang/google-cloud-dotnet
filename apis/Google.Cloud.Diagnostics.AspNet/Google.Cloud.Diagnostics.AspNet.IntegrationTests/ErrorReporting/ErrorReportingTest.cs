﻿// Copyright 2018 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Cloud.Diagnostics.Common.IntegrationTests;
using Google.Cloud.Diagnostics.Common.Tests;
using Google.Cloud.ErrorReporting.V1Beta1;
using Microsoft.Owin.Testing;
using Owin;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Xunit;

namespace Google.Cloud.Diagnostics.AspNet.IntegrationTests
{
    public class ErrorReportingTest
    {
        private readonly ErrorEventEntryPolling _polling = new ErrorEventEntryPolling();

        [Fact]
        public async Task NoExceptions()
        {
            string testId = Utils.GetTestId();
            DateTime startTime = DateTime.UtcNow;

            using (TestServer server = TestServer.Create<ErrorReportingTestApplication>())
            using (var client = server.HttpClient)
            {
                await client.GetAsync($"api/ErrorReporting/Index/{testId}");

                var errorEvents = _polling.GetEvents(startTime, testId, 0);
                Assert.Empty(errorEvents);
            }
        }

        [Fact]
        public async Task LogsException()
        {
            string testId = Utils.GetTestId();
            DateTime startTime = DateTime.UtcNow;

            using (TestServer server = TestServer.Create<ErrorReportingTestApplication>())
            using (var client = server.HttpClient)
            {
                var response = await client.GetAsync($"api/ErrorReporting/ThrowsException/{testId}");
                var contentTask = response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

                var errorEvent = _polling.GetEvents(startTime, testId, 1).Single();
                VerifyAutomaticLogging(errorEvent, testId, "ThrowsException");

                var content = await contentTask;
                Assert.Contains("ThrowsException", content);
                Assert.Contains(testId, content);
            }
        }

        [Fact]
        public async Task LogsMultipleExceptions()
        {
            string testId = Utils.GetTestId();
            DateTime startTime = DateTime.UtcNow;

            using (TestServer server = TestServer.Create<ErrorReportingTestApplication>())
            using (var client = server.HttpClient)
            {
                var requestTask1 = client.GetAsync($"api/ErrorReporting/ThrowsException/{testId}");
                var requestTask2 = client.GetAsync($"api/ErrorReporting/ThrowsArgumentException/{testId}");
                var requestTask3 = client.GetAsync($"api/ErrorReporting/ThrowsException/{testId}");
                var requestTask4 = client.GetAsync($"api/ErrorReporting/ThrowsException/{testId}");

                var response = await requestTask1;
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
                response = await requestTask2;
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
                response = await requestTask3;
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
                response = await requestTask4;
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

                var errorEvents = _polling.GetEvents(startTime, testId, 4);
                Assert.Equal(4, errorEvents.Count());

                var exceptionEvents = errorEvents.Where(e => e.Message.Contains("ThrowsException"));
                Assert.Equal(3, exceptionEvents.Count());
                foreach (var errorEvent in exceptionEvents)
                {
                    VerifyAutomaticLogging(errorEvent, testId, "ThrowsException");
                }

                var argumentExceptionEvent = errorEvents
                    .Where(e => e.Message.Contains("ThrowsArgumentException"))
                    .Single();
                VerifyAutomaticLogging(argumentExceptionEvent, testId, "ThrowsArgumentException");
            }
        }

        [Fact]
        public async Task LogsThrownInHttpMessageHandler()
        {
            string testId = Utils.GetTestId();
            DateTime startTime = DateTime.UtcNow;

            using (TestServer server = TestServer.Create<ErrorReportingTestApplication>())
            using (var client = server.HttpClient)
            {
                var response = await server.HttpClient.GetAsync($"handler/{testId}");
                Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

                var errorEvent = _polling.GetEvents(startTime, testId, 1).Single();
                VerifyAutomaticLogging(errorEvent, testId, "SendAsync");
            }
        }

        [Fact]
        public async Task ManualLog()
        {
            string testId = Utils.GetTestId();
            DateTime startTime = DateTime.UtcNow;

            using (TestServer server = TestServer.Create<ErrorReportingTestApplication>())
            using (var client = server.HttpClient)
            {
                var response = await client.GetAsync($"api/ErrorReporting/ThrowCatchLog/{testId}");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var errorEvent = _polling.GetEvents(startTime, testId, 1).Single();
                VerifyManualLogging(errorEvent, testId, "ThrowCatchLog");
            }
        }

        private void VerifyAutomaticLogging(ErrorEvent errorEvent, string testId, string functionName)
        {
            VerifyErrorEvent(errorEvent, testId, functionName);
            VerifyHttpRequestContext(errorEvent);
        }

        private void VerifyManualLogging(ErrorEvent errorEvent, string testId, string functionName)
        {
            VerifyErrorEvent(errorEvent, testId, functionName);
        }

        /// <summary>
        /// Checks that an <see cref="ErrorEvent"/> contains valid data.
        /// </summary>
        /// <param name="errorEvent">The event to check.</param>
        /// <param name="testId">The id of the test.</param>
        /// <param name="functionName">The name of the function the error occurred in.</param>
        private void VerifyErrorEvent(ErrorEvent errorEvent, string testId, string functionName)
        {
            Assert.Equal(ErrorReportingController.Service, errorEvent.ServiceContext.Service);
            Assert.Equal(ErrorReportingController.Version, errorEvent.ServiceContext.Version);

            Assert.Contains(functionName, errorEvent.Message);
            Assert.Contains(testId, errorEvent.Message);

            if (Utils.IsWindows())
            {
                Assert.False(string.IsNullOrWhiteSpace(errorEvent.Context.ReportLocation.FilePath));
                Assert.True(errorEvent.Context.ReportLocation.LineNumber > 0);
            }
            Assert.Equal(functionName, errorEvent.Context.ReportLocation.FunctionName);
        }

        /// <summary>
        /// Only for automatic logging, in self hosted web apis <see cref="HttpContext.Current"/>
        /// is <code>null</code>.
        /// </summary>
        private void VerifyHttpRequestContext(ErrorEvent errorEvent)
        {
            Assert.Equal(HttpMethod.Get.Method, errorEvent.Context.HttpRequest.Method);
            Assert.False(string.IsNullOrWhiteSpace(errorEvent.Context.HttpRequest.Url));
        }

        private class ErrorReportingTestApplication : HttpApplication
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();
                Register(config);
                app.UseWebApi(config);
            }

            private static void Register(HttpConfiguration config)
            {
                config.Services.Add(typeof(System.Web.Http.ExceptionHandling.IExceptionLogger),
                    ErrorReportingExceptionLogger.Create(ErrorReportingController.ProjectId, ErrorReportingController.Service, ErrorReportingController.Version));

                config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                config.Routes.MapHttpRoute(
                    name: "MessageHandler",
                    routeTemplate: "handler/{id}",
                    null, null,
                    new ThrowErrorHandler());
            }
        }
    }

    /// <summary>
    /// A simple http handler that just throws an exception with the <see cref="_testId"/>
    /// as the message.
    /// </summary>
    public class ThrowErrorHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string id = request.GetRouteData().Values["id"].ToString();
            string message = ErrorReportingController.GetMessage(nameof(SendAsync), id);
            throw new Exception(message);
        }
    };

    /// <summary>
    /// A controller for the <see cref="ErrorReportingTestApplication"/> used to log exceptions.
    /// </summary>
    public class ErrorReportingController : ApiController
    {
        public const string Service = "service-name";
        public const string Version = "version-id";
        public static readonly string ProjectId = Utils.GetProjectIdFromEnvironment();

        private readonly IExceptionLogger _exceptionLogger;
        public ErrorReportingController()
        {
            _exceptionLogger = GoogleExceptionLogger.Create(ProjectId, Service, Version);
        }

        /// <summary>Throws and catches exception.</summary>
        [HttpGet]
        public string Index(string id)
        {
            var message = GetMessage(nameof(Index), id);
            try
            {
                throw new Exception(message);
            }
            catch
            {
                // Do nothing.
            }
            return message;
        }

        /// <summary>Throws an <see cref="Exception"/>.</summary>
        [HttpGet]
        public string ThrowsException(string id)
        {
            string message = GetMessage(nameof(ThrowsException), id);
            throw new Exception(message);
        }

        /// <summary>Throws an <see cref="ArgumentException"/>.</summary>
        [HttpGet]
        public string ThrowsArgumentException(string id)
        {
            string message = GetMessage(nameof(ThrowsArgumentException), id);
            throw new ArgumentException(message);
        }

        /// <summary>Throws, catches and logs an <see cref="Exception"/>.</summary>
        [HttpGet]
        public string ThrowCatchLog(string id)
        {
            var message = GetMessage(nameof(ThrowCatchLog), id);
            try
            {
                throw new Exception(message);
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e);
            }
            return message;
        }

        internal static string GetMessage(string message, string id) => $"{message} - {id}";
    }
}
