using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace kr.bbon.Core.DataSets
{
    public class LanguageDataSet
    {
        private const string RESOURCE_NAME = "Languages.json";

        public LanguageDataSet()
        {
            LoadDataSource();
        }

        public IEnumerable<LanguageModel> Languages { get; private set; } = Enumerable.Empty<LanguageModel>();

        private void LoadDataSource()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                AllowTrailingCommas = true,
            };

            var currentAssembly = GetType().Assembly;
            var resourceName = currentAssembly
                .GetManifestResourceNames()
                .Where(name => name.EndsWith(RESOURCE_NAME))
                .FirstOrDefault();

            string jsonData = null;
            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                using (var stream = currentAssembly.GetManifestResourceStream(resourceName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        jsonData = reader.ReadToEnd();
                        reader.Close();
                    }
                    stream.Close();
                }
            }

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                Languages = JsonSerializer.Deserialize<IEnumerable<LanguageModel>>(jsonData, jsonOptions);
            }
        }

        public bool IsValidCode(string languageCode, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return null != FindByCode(languageCode, stringComparison);
        }

        public string GetCodeFromName(string languageCode, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return FindByCode(languageCode, stringComparison)?.Names.FirstOrDefault();
        }

        public LanguageModel FindByCode(string languageCode, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (Languages.Any())
            {
                return Languages.FirstOrDefault(language => language.Code.Equals(languageCode, stringComparison));
            }

            return null;
        }
    }

    /// <summary>
    /// Represent language
    /// </summary>
    public class LanguageModel
    {
        /// <summary>
        /// ISO language name
        /// </summary>
        public IEnumerable<string> Names { get; set; }

        /// <summary>
        /// Two letter code; ISO 639-1
        /// </summary>
        public string Code { get; set; }

        public IEnumerable<string> NormaizedNames { get => Names.Select(name => name.ToLower()).ToArray(); }

        public string Name { get => Names.First(); }

        public string NormalizedName { get => Names.First().ToLower(); }

        public string NormalizedCode { get => Code.ToLower(); }
    }
}
