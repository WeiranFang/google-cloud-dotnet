// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/logging/v2/logging.proto
// </auto-generated>
// Original file comments:
// Copyright 2017 Google Inc.
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
//
#pragma warning disable 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Google.Cloud.Logging.V2 {
  /// <summary>
  /// Service for ingesting and querying logs.
  /// </summary>
  public static partial class LoggingServiceV2
  {
    static readonly string __ServiceName = "google.logging.v2.LoggingServiceV2";

    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.DeleteLogRequest> __Marshaller_DeleteLogRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.DeleteLogRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.WriteLogEntriesRequest> __Marshaller_WriteLogEntriesRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.WriteLogEntriesRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.WriteLogEntriesResponse> __Marshaller_WriteLogEntriesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.WriteLogEntriesResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.ListLogEntriesRequest> __Marshaller_ListLogEntriesRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.ListLogEntriesRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.ListLogEntriesResponse> __Marshaller_ListLogEntriesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.ListLogEntriesResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest> __Marshaller_ListMonitoredResourceDescriptorsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse> __Marshaller_ListMonitoredResourceDescriptorsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.ListLogsRequest> __Marshaller_ListLogsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.ListLogsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Logging.V2.ListLogsResponse> __Marshaller_ListLogsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Logging.V2.ListLogsResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Google.Cloud.Logging.V2.DeleteLogRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteLog = new grpc::Method<global::Google.Cloud.Logging.V2.DeleteLogRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteLog",
        __Marshaller_DeleteLogRequest,
        __Marshaller_Empty);

    static readonly grpc::Method<global::Google.Cloud.Logging.V2.WriteLogEntriesRequest, global::Google.Cloud.Logging.V2.WriteLogEntriesResponse> __Method_WriteLogEntries = new grpc::Method<global::Google.Cloud.Logging.V2.WriteLogEntriesRequest, global::Google.Cloud.Logging.V2.WriteLogEntriesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "WriteLogEntries",
        __Marshaller_WriteLogEntriesRequest,
        __Marshaller_WriteLogEntriesResponse);

    static readonly grpc::Method<global::Google.Cloud.Logging.V2.ListLogEntriesRequest, global::Google.Cloud.Logging.V2.ListLogEntriesResponse> __Method_ListLogEntries = new grpc::Method<global::Google.Cloud.Logging.V2.ListLogEntriesRequest, global::Google.Cloud.Logging.V2.ListLogEntriesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ListLogEntries",
        __Marshaller_ListLogEntriesRequest,
        __Marshaller_ListLogEntriesResponse);

    static readonly grpc::Method<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest, global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse> __Method_ListMonitoredResourceDescriptors = new grpc::Method<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest, global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ListMonitoredResourceDescriptors",
        __Marshaller_ListMonitoredResourceDescriptorsRequest,
        __Marshaller_ListMonitoredResourceDescriptorsResponse);

    static readonly grpc::Method<global::Google.Cloud.Logging.V2.ListLogsRequest, global::Google.Cloud.Logging.V2.ListLogsResponse> __Method_ListLogs = new grpc::Method<global::Google.Cloud.Logging.V2.ListLogsRequest, global::Google.Cloud.Logging.V2.ListLogsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ListLogs",
        __Marshaller_ListLogsRequest,
        __Marshaller_ListLogsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Google.Cloud.Logging.V2.LoggingReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of LoggingServiceV2</summary>
    public abstract partial class LoggingServiceV2Base
    {
      /// <summary>
      /// Deletes all the log entries in a log.
      /// The log reappears if it receives new entries.
      /// Log entries written shortly before the delete operation might not be
      /// deleted.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteLog(global::Google.Cloud.Logging.V2.DeleteLogRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// ## Log entry resources
      ///
      /// Writes log entries to Stackdriver Logging. This API method is the
      /// only way to send log entries to Stackdriver Logging. This method
      /// is used, directly or indirectly, by the Stackdriver Logging agent
      /// (fluentd) and all logging libraries configured to use Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Google.Cloud.Logging.V2.WriteLogEntriesResponse> WriteLogEntries(global::Google.Cloud.Logging.V2.WriteLogEntriesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Lists log entries.  Use this method to retrieve log entries from
      /// Stackdriver Logging.  For ways to export log entries, see
      /// [Exporting Logs](/logging/docs/export).
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Google.Cloud.Logging.V2.ListLogEntriesResponse> ListLogEntries(global::Google.Cloud.Logging.V2.ListLogEntriesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Lists the descriptors for monitored resource types used by Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse> ListMonitoredResourceDescriptors(global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Lists the logs in projects, organizations, folders, or billing accounts.
      /// Only logs that have entries are listed.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Google.Cloud.Logging.V2.ListLogsResponse> ListLogs(global::Google.Cloud.Logging.V2.ListLogsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for LoggingServiceV2</summary>
    public partial class LoggingServiceV2Client : grpc::ClientBase<LoggingServiceV2Client>
    {
      /// <summary>Creates a new client for LoggingServiceV2</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public LoggingServiceV2Client(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for LoggingServiceV2 that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public LoggingServiceV2Client(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected LoggingServiceV2Client() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected LoggingServiceV2Client(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Deletes all the log entries in a log.
      /// The log reappears if it receives new entries.
      /// Log entries written shortly before the delete operation might not be
      /// deleted.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteLog(global::Google.Cloud.Logging.V2.DeleteLogRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Deletes all the log entries in a log.
      /// The log reappears if it receives new entries.
      /// Log entries written shortly before the delete operation might not be
      /// deleted.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteLog(global::Google.Cloud.Logging.V2.DeleteLogRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteLog, null, options, request);
      }
      /// <summary>
      /// Deletes all the log entries in a log.
      /// The log reappears if it receives new entries.
      /// Log entries written shortly before the delete operation might not be
      /// deleted.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteLogAsync(global::Google.Cloud.Logging.V2.DeleteLogRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Deletes all the log entries in a log.
      /// The log reappears if it receives new entries.
      /// Log entries written shortly before the delete operation might not be
      /// deleted.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteLogAsync(global::Google.Cloud.Logging.V2.DeleteLogRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteLog, null, options, request);
      }
      /// <summary>
      /// ## Log entry resources
      ///
      /// Writes log entries to Stackdriver Logging. This API method is the
      /// only way to send log entries to Stackdriver Logging. This method
      /// is used, directly or indirectly, by the Stackdriver Logging agent
      /// (fluentd) and all logging libraries configured to use Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.WriteLogEntriesResponse WriteLogEntries(global::Google.Cloud.Logging.V2.WriteLogEntriesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return WriteLogEntries(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// ## Log entry resources
      ///
      /// Writes log entries to Stackdriver Logging. This API method is the
      /// only way to send log entries to Stackdriver Logging. This method
      /// is used, directly or indirectly, by the Stackdriver Logging agent
      /// (fluentd) and all logging libraries configured to use Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.WriteLogEntriesResponse WriteLogEntries(global::Google.Cloud.Logging.V2.WriteLogEntriesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_WriteLogEntries, null, options, request);
      }
      /// <summary>
      /// ## Log entry resources
      ///
      /// Writes log entries to Stackdriver Logging. This API method is the
      /// only way to send log entries to Stackdriver Logging. This method
      /// is used, directly or indirectly, by the Stackdriver Logging agent
      /// (fluentd) and all logging libraries configured to use Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.WriteLogEntriesResponse> WriteLogEntriesAsync(global::Google.Cloud.Logging.V2.WriteLogEntriesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return WriteLogEntriesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// ## Log entry resources
      ///
      /// Writes log entries to Stackdriver Logging. This API method is the
      /// only way to send log entries to Stackdriver Logging. This method
      /// is used, directly or indirectly, by the Stackdriver Logging agent
      /// (fluentd) and all logging libraries configured to use Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.WriteLogEntriesResponse> WriteLogEntriesAsync(global::Google.Cloud.Logging.V2.WriteLogEntriesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_WriteLogEntries, null, options, request);
      }
      /// <summary>
      /// Lists log entries.  Use this method to retrieve log entries from
      /// Stackdriver Logging.  For ways to export log entries, see
      /// [Exporting Logs](/logging/docs/export).
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.ListLogEntriesResponse ListLogEntries(global::Google.Cloud.Logging.V2.ListLogEntriesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListLogEntries(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Lists log entries.  Use this method to retrieve log entries from
      /// Stackdriver Logging.  For ways to export log entries, see
      /// [Exporting Logs](/logging/docs/export).
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.ListLogEntriesResponse ListLogEntries(global::Google.Cloud.Logging.V2.ListLogEntriesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ListLogEntries, null, options, request);
      }
      /// <summary>
      /// Lists log entries.  Use this method to retrieve log entries from
      /// Stackdriver Logging.  For ways to export log entries, see
      /// [Exporting Logs](/logging/docs/export).
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.ListLogEntriesResponse> ListLogEntriesAsync(global::Google.Cloud.Logging.V2.ListLogEntriesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListLogEntriesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Lists log entries.  Use this method to retrieve log entries from
      /// Stackdriver Logging.  For ways to export log entries, see
      /// [Exporting Logs](/logging/docs/export).
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.ListLogEntriesResponse> ListLogEntriesAsync(global::Google.Cloud.Logging.V2.ListLogEntriesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ListLogEntries, null, options, request);
      }
      /// <summary>
      /// Lists the descriptors for monitored resource types used by Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse ListMonitoredResourceDescriptors(global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListMonitoredResourceDescriptors(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Lists the descriptors for monitored resource types used by Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse ListMonitoredResourceDescriptors(global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ListMonitoredResourceDescriptors, null, options, request);
      }
      /// <summary>
      /// Lists the descriptors for monitored resource types used by Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse> ListMonitoredResourceDescriptorsAsync(global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListMonitoredResourceDescriptorsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Lists the descriptors for monitored resource types used by Stackdriver
      /// Logging.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsResponse> ListMonitoredResourceDescriptorsAsync(global::Google.Cloud.Logging.V2.ListMonitoredResourceDescriptorsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ListMonitoredResourceDescriptors, null, options, request);
      }
      /// <summary>
      /// Lists the logs in projects, organizations, folders, or billing accounts.
      /// Only logs that have entries are listed.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.ListLogsResponse ListLogs(global::Google.Cloud.Logging.V2.ListLogsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListLogs(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Lists the logs in projects, organizations, folders, or billing accounts.
      /// Only logs that have entries are listed.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Logging.V2.ListLogsResponse ListLogs(global::Google.Cloud.Logging.V2.ListLogsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ListLogs, null, options, request);
      }
      /// <summary>
      /// Lists the logs in projects, organizations, folders, or billing accounts.
      /// Only logs that have entries are listed.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.ListLogsResponse> ListLogsAsync(global::Google.Cloud.Logging.V2.ListLogsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListLogsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Lists the logs in projects, organizations, folders, or billing accounts.
      /// Only logs that have entries are listed.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Logging.V2.ListLogsResponse> ListLogsAsync(global::Google.Cloud.Logging.V2.ListLogsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ListLogs, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override LoggingServiceV2Client NewInstance(ClientBaseConfiguration configuration)
      {
        return new LoggingServiceV2Client(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(LoggingServiceV2Base serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_DeleteLog, serviceImpl.DeleteLog)
          .AddMethod(__Method_WriteLogEntries, serviceImpl.WriteLogEntries)
          .AddMethod(__Method_ListLogEntries, serviceImpl.ListLogEntries)
          .AddMethod(__Method_ListMonitoredResourceDescriptors, serviceImpl.ListMonitoredResourceDescriptors)
          .AddMethod(__Method_ListLogs, serviceImpl.ListLogs).Build();
    }

  }
}
#endregion
