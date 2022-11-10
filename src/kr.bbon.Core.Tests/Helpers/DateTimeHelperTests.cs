using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kr.bbon.Core.Helpers;

using Xunit;

namespace kr.bbon.Core.Tests.Helpers
{
    public class DateTimeHelperTests
    {
        // [Fact(DisplayName = "Should have offset of time zone")]
        [Theory]
        [InlineData("Asia/Seoul")]
        [InlineData("America/Los_Angeles")]
        public void ShouldHaveOffsetOfTimeZoneLocal(string timeZoneId)
        {
            var timeZoneInfo = new TimeZoneHelper().FindSystemTimeZoneById(timeZoneId);

            var now = DateTime.Now;

            // var dateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            DateTimeHelper helper = new();

            var dateTimeWithOffset = helper.ApplyTimeZone(now, timeZoneInfo);
            var offset = timeZoneInfo.BaseUtcOffset;
            var expected = $"{(offset.Hours >= 0 ? "+" : "")}{offset.Hours:00}:{offset.Minutes:00}";

            // Console.WriteLine($"Source  ={now:yyyy-MM-ddTHH:mm:sszzz}");
            // Console.WriteLine($"Value   ={dateTimeWithOffset:yyyy-MM-ddTHH:mm:sszzz}");
            // Console.WriteLine($"expected={expected}");
            // Console.WriteLine($"actual  ={dateTimeWithOffset.ToString("zzz")}");

            Assert.Equal(expected, dateTimeWithOffset.ToString("zzz"));
        }

        [Fact(DisplayName = "Should be Utc dateTimeOffset instance #1 (DateTime.Now)")]
        public void ShouldBeUtcDateTimeOffsetInstance()
        {
            var now = DateTime.Now;
            DateTimeHelper helper = new();

            var dateTimeWithOffset = helper.GetUtcDateTimeOffset(now);

            var expected = $"+00:00";

            Assert.Equal(expected, dateTimeWithOffset.ToString("zzz"));
        }

        [Fact(DisplayName = "Should be Utc dateTimeOffset instance #2 (DateTimeKind.Unspecified)")]
        public void ShouldBeUtcDateTimeOffsetInstance2()
        {
            var now = new DateTime(2022, 11, 10, 0, 0, 0, DateTimeKind.Unspecified);
            DateTimeHelper helper = new();

            var dateTimeWithOffset = helper.GetUtcDateTimeOffset(now);

            var expected = $"+00:00";

            Assert.Equal(expected, dateTimeWithOffset.ToString("zzz"));
        }

        [Fact(DisplayName = "Should be Utc dateTimeOffset instance #3 (DateTimeKind.Utc)")]
        public void ShouldBeUtcDateTimeOffsetInstance3()
        {
            var now = new DateTime(2022, 11, 10, 0, 0, 0, DateTimeKind.Utc);
            DateTimeHelper helper = new();

            var dateTimeWithOffset = helper.GetUtcDateTimeOffset(now);

            var expected = $"+00:00";

            Assert.Equal(expected, dateTimeWithOffset.ToString("zzz"));
        }

        [Fact(DisplayName = "Should be Utc dateTimeOffset instance #4 (DateTimeKind.Local)")]
        public void ShouldBeUtcDateTimeOffsetInstance4()
        {
            var now = new DateTime(2022, 11, 10, 0, 0, 0, DateTimeKind.Local);
            DateTimeHelper helper = new();

            var dateTimeWithOffset = helper.GetUtcDateTimeOffset(now);

            var expected = $"+00:00";

            Assert.Equal(expected, dateTimeWithOffset.ToString("zzz"));
        }




    }
}
