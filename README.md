[![](https://img.shields.io/nuget/v/soenneker.twilio.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.twilio.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.twilio.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.openapiclient/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.twilio.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Twilio.OpenApiClient

A Kiota-generated client for Twilio APIs, with typed request builders and response models across Twilio products.

## Installation

```bash
dotnet add package Soenneker.Twilio.OpenApiClient
```

## Usage

The generated client accepts a Kiota request adapter. The caller owns the adapter and its `HttpClient`:

```csharp
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Twilio.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.twilio.com/")
};

string credentials = Convert.ToBase64String(
    Encoding.ASCII.GetBytes($"{apiKey}:{apiSecret}"));

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Basic", credentials);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new TwilioOpenApiClient(adapter);
```

Twilio exposes different products from different hosts. When an operation does not use the adapter's base URL, select the generated request builder and pin its complete endpoint with `WithUrl`:

```csharp
string phoneNumber = "+15551234567";
string url = $"https://lookups.twilio.com/v1/PhoneNumbers/{Uri.EscapeDataString(phoneNumber)}";

var result = await client.Twilio_lookups_v1
    .V1
    .PhoneNumbers[phoneNumber]
    .WithUrl(url)
    .GetAsync(cancellationToken: cancellationToken);
```

Use a Twilio API key SID and secret for `apiKey` and `apiSecret`. API errors are thrown through Kiota's normal exception handling. If you want configuration-based authentication and service registration, use `Soenneker.Twilio.OpenApiClientUtil` instead.
