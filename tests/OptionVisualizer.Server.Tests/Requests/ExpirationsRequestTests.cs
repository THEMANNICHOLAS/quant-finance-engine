using OptionVisualizer.Server.Services.Api.Requests;
using Xunit;

namespace OptionVisualizer.Server.Tests.Requests;

public class ExpirationsRequestTests
{
    [Fact]
    public void GetPath_EncodesUnderlying()
    {
        var request = new ExpirationsRequest("NYSE:SPY");

        var path = request.GetPath();

        Assert.Equal("/v1/options/expirations/NYSE%3ASPY/", path);
    }

    [Fact]
    public void RequestUrlBuilder_Build_SkipsNullOrEmptyQueryValues()
    {
        var request = new ExpirationsRequest("SPY")
        {
            Date = null,
            Strike = "",
            DateFormat = "timestamp"
        };

        var url = RequestUrlBuilder.Build(
            request.ToQueryParams(),
            "https://api.marketdata.app",
            request.GetPath());

        Assert.Equal(
            "https://api.marketdata.app/v1/options/expirations/SPY?format=json&dateformat=timestamp",
            url);
    }

    [Fact]
    public void RequestUrlBuilder_Build_ThrowsWhenBaseUrlMissing()
    {
        var request = new ExpirationsRequest("SPY");

        Assert.Throws<ArgumentException>(() =>
            RequestUrlBuilder.Build(request.ToQueryParams(), "", request.GetPath()));
    }
}
