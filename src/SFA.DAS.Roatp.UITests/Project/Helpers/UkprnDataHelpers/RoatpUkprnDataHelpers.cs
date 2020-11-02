using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public abstract class RoatpUkprnDataHelpers
    {
        protected readonly Dictionary<string, List<KeyValuePair<string, string>>> _applyData;
        protected readonly Dictionary<string, List<KeyValuePair<string, string>>> _adminData;
        protected readonly Dictionary<string, List<KeyValuePair<string, string>>> _e2eData;

        protected const string ukprnkey = "ukprnkey";
        protected const string providernamekey = "providernamekey";
        protected const string emailkey = "emailkey";

        public RoatpUkprnDataHelpers()
        {
            _adminData = new Dictionary<string, List<KeyValuePair<string, string>>>();
            _applyData = new Dictionary<string, List<KeyValuePair<string, string>>>();
            _e2eData = new Dictionary<string, List<KeyValuePair<string, string>>>();
        }

        protected (string value1, string value2) GetData(List<KeyValuePair<string, string>> keyValuePair, string value1Key, string value2Key)
        {
            return (keyValuePair.First(x => x.Key == value1Key).Value, keyValuePair.First(x => x.Key == value2Key).Value);
        }

        protected (string value1, string value2, string value3) GetData(List<KeyValuePair<string, string>> keyValuePair, string value1Key, string value2Key, string value3Key)
        {
            var (value1, value2) = GetData(keyValuePair, value1Key, value2Key);

            return (value1, value2, keyValuePair.First(x => x.Key == value3Key).Value);
        }

        protected List<KeyValuePair<string, string>> FindKeyValuePairs(Dictionary<string, List<KeyValuePair<string, string>>> dictionary, string key)
        {
            return dictionary.TryGetValue(key, out var keyValuePair) ? keyValuePair : throw new KeyNotFoundException($"Can not find data for key {key}");
        }
    }
}
