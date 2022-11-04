using System;
namespace kr.bbon.Core.Helpers
{
    public class TimeZoneHelper
    {
        /// <summary>
        /// Create TimeZoneInfo instance
        /// </summary>
        /// <remarks>
        /// <para>Find the time zone with the timezoneId argument.</para>
        /// <para>Convert Iana id to Windows time zone id on  windows.</para>
        /// <para>Convert Windows time zone id to Iana id on Linux or unix.</para>
        /// <para>Caution: .NET 6 or greater is required. Does not support .NET Standard 2.0, .NET 5</para>
        /// </remarks>
        /// <param name="timeZoneId"></param>
        /// <param name="throwsExceptionWhenTimeZoneInfoNotFound"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidTimeZoneException"></exception>
        public TimeZoneInfo FindSystemTimeZoneById(string timeZoneId, bool throwsExceptionWhenTimeZoneInfoNotFound = false)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
            {
                throw new ArgumentException("Time zone id is required.", nameof(timeZoneId));
            }

            TimeZoneInfo timeZoneInfo = null;
            try
            {
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch
            {

#if NET6_0_OR_GREATER
                if (OperatingSystem.IsWindows())
                {
                    if (TimeZoneInfo.TryConvertIanaIdToWindowsId(timeZoneId, out string windowsId))
                    {
                        timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(windowsId);
                    }
                }
                else
                {
                    if (TimeZoneInfo.TryConvertWindowsIdToIanaId(timeZoneId, out string ianaId))
                    {
                        timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(ianaId);
                    }
                }
#endif
                if (timeZoneInfo == null && throwsExceptionWhenTimeZoneInfoNotFound)
                {
                    throw new InvalidTimeZoneException();
                }
            }

            return timeZoneInfo;
        }
    }
}

