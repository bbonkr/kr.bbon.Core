using System;

using TimeZoneConverter;

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
                timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);
            }
            catch 
            {
                if (timeZoneInfo == null && throwsExceptionWhenTimeZoneInfoNotFound)
                {
                    throw;
                }
            }

            return timeZoneInfo;
        }
    }
}

