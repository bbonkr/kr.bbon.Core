using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kr.bbon.Core.Helpers;

using Xunit;

namespace kr.bbon.Core.Tests.Helpers;

public class TimeZoneHelperTests
{
    [Fact(DisplayName ="Should be found time zone with Iana Id")]
    public void ShouldBeFoundTimeZoneWithIanaId()
    {
        var timeZoneId = "Asia/Seoul";
        var standardName = "Korea Standard Time"; //OperatingSystem.IsWindows() ? "Korea Standard Time" : "Asia/Seoul";

        TimeZoneHelper helper = new TimeZoneHelper();
        var timeZoneInfo = helper.FindSystemTimeZoneById(timeZoneId);

        Assert.NotNull(timeZoneInfo);
        Assert.Equal(standardName, timeZoneInfo.StandardName);
    }

    [Fact(DisplayName ="Should be found time zone with windows time zone id")]
    public void ShouldBeFoundTimeZoneWithWindowsTimeZoneId()
    {
        var timeZoneId = "Korea Standard Time";
        var standardName = "Korea Standard Time"; //OperatingSystem.IsWindows() ? "Korea Standard Time" : "Asia/Seoul";

        TimeZoneHelper helper = new TimeZoneHelper();
        var timeZoneInfo = helper.FindSystemTimeZoneById(timeZoneId);

        Assert.NotNull(timeZoneInfo);
        Assert.Equal(standardName, timeZoneInfo.StandardName);
    }

    [Fact(DisplayName ="Should not be found time zone with invalid Iana id")]
    public void ShouldNotBeFoundTimeZoneWithIanaId()
    {
        var timeZoneId = "asia/seoul";

        TimeZoneHelper helper = new TimeZoneHelper();
        var timeZoneInfo = helper.FindSystemTimeZoneById(timeZoneId);

        Assert.Null(timeZoneInfo);
    }

    [Fact(DisplayName = "Should not be found time zone with invalid windows time zone id")]
    public void ShouldNotBeFoundTimeZoneWithWindowsTimeZoneId()
    {
        var timeZoneId = "korea standard tim";

        TimeZoneHelper helper = new TimeZoneHelper();
        var timeZoneInfo = helper.FindSystemTimeZoneById(timeZoneId);

        Assert.Null(timeZoneInfo);
    }
}
