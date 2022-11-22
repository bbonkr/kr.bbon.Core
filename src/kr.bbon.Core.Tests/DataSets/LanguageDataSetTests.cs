using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kr.bbon.Core.DataSets;

using Xunit;

namespace kr.bbon.Core.Tests.DataSets
{
    public class LanguageDataSetTests
    {
        public LanguageDataSetTests()
        {
            languageDataSet = new LanguageDataSet();
        }

        [Fact]
        public void ShouldBeNotEmpty()
        {
            Assert.True(languageDataSet.Languages.Count() > 0);
            foreach (var language in languageDataSet.Languages)
            {
                Assert.DoesNotContain(language.Names, name => string.IsNullOrWhiteSpace(name));
                Assert.True(!string.IsNullOrWhiteSpace(language.Code));
            }
        }

        [Theory]
        [InlineData("ko")]
        [InlineData("en")]
        [InlineData("ru")]
        [InlineData("ja")]
        public void ShouldBeValid(string languageCode)
        {
            var actual=languageDataSet.IsValidCode(languageCode);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("ko")]
        [InlineData("KO")]
        [InlineData("Ko")]
        [InlineData("kO")]
        [InlineData("en")]
        [InlineData("ru")]
        [InlineData("ja")]
        public void ShouldFind(string languageCode)
        {
            var found = languageDataSet.FindByCode(languageCode);
            Assert.Equal(languageCode.ToLower(), found.NormalizedCode);
        }

        [Theory]
        [InlineData("ko1")]
        [InlineData("en1")]
        [InlineData("ru1")]
        [InlineData("ja1")]
        public void ShouldBeNull(string languageCode)
        {
            var notfound = languageDataSet.FindByCode(languageCode);
            Assert.Null(notfound);
        }

        private readonly LanguageDataSet languageDataSet;
    }
}
