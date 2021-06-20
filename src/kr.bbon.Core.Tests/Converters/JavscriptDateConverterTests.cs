using kr.bbon.Core.Converters;
using System;
using Xunit;

namespace kr.bbon.Core.Tests
{
    public class JavscriptDateConverterTests
    {
        [Fact(DisplayName = "When Pass Javascript Date milliseconds value, converted value should be equals.")]
        public void Should_Be_Equals_Converted_Value()
        {
            JavascriptDateConverter converter = new JavascriptDateConverter();
            var javascriptDateValue = 1624165031491;
            var datetimeOffsetValue = converter.ToDateTimeOffset(javascriptDateValue);
            var milliseconds = converter.ToJavascriptDateMilliseconds(datetimeOffsetValue);

            Assert.True(datetimeOffsetValue.HasValue);
            Assert.True(milliseconds.HasValue);
            Assert.Equal(javascriptDateValue, milliseconds.Value);
        }

        [Fact(DisplayName ="If pass null, result is null")]
        public void Should_Be_Null_Pass_Null()
        {
            JavascriptDateConverter converter = new JavascriptDateConverter();
            double? javascriptDateValue = null;
            var datetimeOffsetValue = converter.ToDateTimeOffset(javascriptDateValue);
            var milliseconds = converter.ToJavascriptDateMilliseconds(datetimeOffsetValue);

            Assert.False(datetimeOffsetValue.HasValue);
            Assert.False(milliseconds.HasValue);
            Assert.Null(datetimeOffsetValue);
            Assert.Null(milliseconds);

        }
    }
}
