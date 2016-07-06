
# Page streaming

## Introduction

Many Google APIs expose operations to list resources, possibly
filtering them. Often, there may be many, many matching resources,
so the results are returned one "page" at a time. Each request can
specify a *page token* which identifies the start of the page of
results to return, and each response specifies a *next page token*
to use in the subsequent request. If the end of the logical result
list has been reached, the next page token is not specified.

In addition to the resources in the page, a list response can
include extra information such as the total size of the list,
or perhaps the cost of performing the query.

The code required to iterate over all the results in a list is not
difficult, but it is tedious and error-prone, so the C# client
libraries have abstracted this away.

Operations listing resources synchronously return an
[IPagedEnumerable&lt;TResponse, TResource&gt;](../obj/api/Google.Api.Gax.IPagedEnumerable-2.yml), and operations listing
resources asynchronously return an
[IPagedAsyncEnumerable&lt;TResponse, TResource&gt;](../obj/api/Google.Api.Gax.IPagedAsyncEnumerable-2.yml).
These are equivalent other than their asynchrony, so
this document focuses on the synchronous version for simplicity.

## `IPagedEnumerable<TResponse, TResource>`

Let's look at the generic type parameters first. The `TResponse` is
the API response type for the list operation, and the `TResource` is
the type of the resource being listed. In the Pub/Sub API for
example, the `ListTopics` operation accepts a `ListTopicsRequest`
and returns a `ListTopicsResponse` containing a set of `Topic`
resources - so the [PublisherClient.ListTopics](../obj/api/Google.Pubsub.V1.PublisherClient.yml#Google_Pubsub_V1_PublisherClient_ListTopics_System_String_System_String_System_Nullable_System_Int32__Google_Api_Gax_CallSettings_)
method returns an `IPagedEnumerable<ListTopicsResponse, Topic>`.

`IPagedEnumerable<TResponse, TResource>` implements
`IEnumerable<TResource>`.  If you simply iterate over it, you will
retrieve one resource at a time. The implementation will make API
calls as it needs to, retrieving a page at a time and then returning
the resources as the caller requests them.

## `IResourceEnumerable<TResponse, TResource>`

For more advanced scenarios, however, your application may need access
to the pages returned by the API instead. The
[IPagedEnumerable&lt;TResponse, TResource&gt;.AsPages()](../obj/api/Google.Api.Gax.IPagedEnumerable-2.yml#Google_Api_Gax_IPagedEnumerable_2_AsPages)
method returns an [IResponseEnumerable&lt;TResponse, TResource&gt;](../obj/api/Google.Api.Gax.IResponseEnumerable-2.yml) which
implements `IEnumerable<TResponse>`, so you can iterate over the responses easily. Each
response provides access to the individual resources within the page, and some APIs may
provide additional information such as the time taken for the request or the total number of
results across all pages. As you iterate over the pages, API requests are made
transparently, propagating the page token from one response to the next request.

`IResourceEnumerable<TResponse, TResource>` provides one additional method, 
[WithFixedSize()](../obj/api/Google.Api.Gax.IResponseEnumerable-2.yml#Google_Api_Gax_IResponseEnumerable_2_WithFixedSize_System_Int32_)
to cater for web applications which require precise page sizes.

Although APIs generally allow the application to specify the page size to return, this
is an upper limit rather than a hard requirement. It's possible for an API to return fewer results,
even if more are available - for example, if the server notices that it is close to reaching the specified
RPC deadline. While that's fine for many batch scenarios, it isn't ideal if the results are being presented to users,
where typically you want to provide the exact same number of results per page.

The `WithFixedSize` method makes multiple API requests if necessary, in order to "fill" each page
until it reaches the end of the resources being listed. The return value is an `IEnumerable<FixedSizePage<TResource>>`, where
[FixedSizePage&lt;TResource&gt;](../obj/api/Google.Api.Gax.FixedSizePage-1.yml#Google_Api_Gax_FixedSizePage_1) provides the items
within each page, along with the page token used to retrieve the next page. (This would typically be used in a "next page" link
in the web results.)

## Use case sample code

### Iterate over all resources, ignoring pagination

[!code-cs[](../obj/snippets/Google.Pubsub.V1.PublisherClient.txt#PageStreamingUseCases_AllResources)]

### Iterate over all resources, remembering page tokens

[!code-cs[](../obj/snippets/Google.Pubsub.V1.PublisherClient.txt#PageStreamingUseCases_Responses)]

### Obtain a single page of results

[!code-cs[](../obj/snippets/Google.Pubsub.V1.PublisherClient.txt#PageStreamingUseCases_SingleResponse)]

### Display results in fixed-sized pages

This is typically used in web applications.

[!code-cs[](../obj/snippets/Google.Pubsub.V1.PublisherClient.txt#PageStreamingUseCases_WithFixedSize)]

## Feedback

We've already been through a number of iterations of the page-streaming API,
but would very much welcome feedback on it. A few thoughts:

- We could return a concrete class rather than having the `IPagedEnumerable<,>`
  interface. This would give us greater room for expansion in the future, but
  might make faking harder.
- We could move the `WithFixedSize` method into the returned type, so that
  instead of calling `topics.AsPages().WithFixedSize(10)` you'd call
  `topics.WithFixedSizedPages(10)`, for example. This would allow us to remove
  the `IResponseEnumerable<,>` interface.

What other use cases should we consider? Does this meet your current needs?
Please [raise an issue on github](https://github.com/GoogleCloudPlatform/gcloud-dotnet/issues/new)
to provide feedback.