using System;

namespace kr.bbon.Core.Converters
{
    /// <summary>
    /// Javascript Date milliseconds value converter
    /// </summary>
    public class JavascriptDateConverter 
    {
        /// <summary>
        /// Javscript Date milliseconds value to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="javascriptDateMillisecondsValue"></param>
        /// <returns></returns>
        public DateTimeOffset? ToDateTimeOffset(double? javascriptDateMillisecondsValue)
        {
            if (!javascriptDateMillisecondsValue.HasValue)
            {
                return null;
            }

            return JAVASCRIPT_DATE_BASIS.AddMilliseconds(javascriptDateMillisecondsValue.Value);
        }

        /// <summary>
        /// <see cref="DateTimeOffset"/> to Javascript Date milliseconds value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double? ToJavascriptDateMilliseconds(DateTimeOffset? value)
        {
            if (!value.HasValue) { return null; }

            var sourceValue = value.Value;
            return sourceValue.Subtract(JAVASCRIPT_DATE_BASIS).TotalMilliseconds;
        }

        public readonly DateTimeOffset JAVASCRIPT_DATE_BASIS = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
    }
}
