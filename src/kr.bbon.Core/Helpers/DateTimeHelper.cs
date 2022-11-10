using System;

namespace kr.bbon.Core.Helpers
{
    public class DateTimeHelper
    {
        public DateTimeOffset ApplyTimeZone(DateTime dateTimeUtcOrUnspecified, TimeZoneInfo timeZoneInfo)
        {
            var unspecifiedDateTime = new DateTime(dateTimeUtcOrUnspecified.Year, dateTimeUtcOrUnspecified.Month, dateTimeUtcOrUnspecified.Day, dateTimeUtcOrUnspecified.Hour, dateTimeUtcOrUnspecified.Minute, dateTimeUtcOrUnspecified.Second, DateTimeKind.Unspecified);
            var dateTimeOffset = new DateTimeOffset(
                unspecifiedDateTime,
                timeZoneInfo.BaseUtcOffset);

            return dateTimeOffset;
        }

        public DateTimeOffset GetUtcDateTimeOffset(DateTime dateTimeUtcOrUnspecified)
        {
            var unspecifiedDateTime = new DateTime(dateTimeUtcOrUnspecified.Year, dateTimeUtcOrUnspecified.Month, dateTimeUtcOrUnspecified.Day, dateTimeUtcOrUnspecified.Hour, dateTimeUtcOrUnspecified.Minute, dateTimeUtcOrUnspecified.Second, DateTimeKind.Unspecified);
            var dateTimeOffset = new DateTimeOffset(
                unspecifiedDateTime,
                TimeSpan.Zero);

            return dateTimeOffset;
        }
    }
}
