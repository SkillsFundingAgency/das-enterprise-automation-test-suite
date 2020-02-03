using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ApplyUkprnDataHelpers
    {
        private readonly Dictionary<string, List<KeyValuePair<string, string>>> _applyDatas;

        private const string emailkey = "emailkey";
        private const string ukprnkey = "ukprnkey";

        public ApplyUkprnDataHelpers()
        {
            _applyDatas = new Dictionary<string, List<KeyValuePair<string, string>>>();
            AddApplyDatahelpers();
        }

        public (string email, string ukprn) GetApplyData(string key)
        {
            var keyValuePair = FindKeyValuePairs(key);
            var email = keyValuePair.First(x => x.Key == emailkey).Value;
            var ukprn = keyValuePair.First(x => x.Key == ukprnkey).Value;
            return (email, ukprn);
        }

        private List<KeyValuePair<string, string>> FindKeyValuePairs(string key) => _applyDatas.TryGetValue(key, out var keyValuePair) ? keyValuePair : throw new KeyNotFoundException($"Can not find data for key {key}");

        private void AddApplyDatahelpers()
        {
            _applyDatas.Add("rpe2e01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+roatp2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10047117"),
                });

            _applyDatas.Add("rpe2e02",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+employer@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10061310"),
                });
            _applyDatas.Add("rpe2e03",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, ""),
                    new KeyValuePair<string, string>(ukprnkey, ""),
                });
        }
    }
}
