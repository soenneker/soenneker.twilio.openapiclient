using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Twilio.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class TwilioOpenApiClientTests : FixturedUnitTest
{
    public TwilioOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
