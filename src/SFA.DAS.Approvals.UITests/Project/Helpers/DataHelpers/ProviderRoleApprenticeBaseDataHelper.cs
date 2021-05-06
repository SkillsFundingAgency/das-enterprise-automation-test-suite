using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public abstract class ProviderRoleApprenticeBaseDataHelper
    {
        protected readonly Dictionary<string, List<KeyValuePair<string, string>>> _data;

        protected const string firstname = "firstname";
        protected const string lastname = "lastname";

        public ProviderRoleApprenticeBaseDataHelper() => _data = new Dictionary<string, List<KeyValuePair<string, string>>>();


        protected (string value1, string value2) GetData(string key, string value1Key, string value2Key)
        {
            var values = FindKeyValuePairs(key);

            return (FindValue(values, value1Key), FindValue(values, value2Key));
        }

        protected (string value1, string value2, string value3) GetData(string key, string value1Key, string value2Key, string value3Key)
        {
            var values = FindKeyValuePairs(key);

            return (FindValue(values, value1Key), FindValue(values, value2Key), FindValue(values, value3Key));
        }

        private List<KeyValuePair<string, string>> FindKeyValuePairs(string key) => _data.TryGetValue(key, out var keyValuePair) ? keyValuePair : throw new KeyNotFoundException($"Can not find data for key {key}");

        private string FindValue(List<KeyValuePair<string, string>> keyValuePairs, string valuekey) => keyValuePairs.First(x => x.Key == valuekey).Value;
    }
}
