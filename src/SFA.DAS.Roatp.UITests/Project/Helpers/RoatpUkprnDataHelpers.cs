using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public abstract class RoatpUkprnDataHelpers
    {
        protected readonly Dictionary<string, List<KeyValuePair<string, string>>> _applyData;
        protected readonly Dictionary<string, List<KeyValuePair<string, string>>> _adminData;

        protected const string ukprnkey = "ukprnkey";
        protected const string providernamekey = "providernamekey";
        protected const string emailkey = "emailkey";

        public RoatpUkprnDataHelpers()
        {
            _adminData = new Dictionary<string, List<KeyValuePair<string, string>>>();
            _applyData = new Dictionary<string, List<KeyValuePair<string, string>>>();
        }

        protected (string value1, string value2) GetAdminData(List<KeyValuePair<string, string>> keyValuePair, string value1Key, string value2Key)
        {
            return (keyValuePair.First(x => x.Key == value1Key).Value, keyValuePair.First(x => x.Key == value2Key).Value);
        }

        protected List<KeyValuePair<string, string>> FindKeyValuePairs(Dictionary<string, List<KeyValuePair<string, string>>> dictionary, string key)
        {
            return dictionary.TryGetValue(key, out var keyValuePair) ? keyValuePair : throw new KeyNotFoundException($"Can not find data for key {key}");
        }
    }
}
