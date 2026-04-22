using Soenneker.Tests.HostedUnit;

namespace Soenneker.Twilio.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TwilioOpenApiClientTests : HostedUnitTest
{
    public TwilioOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
