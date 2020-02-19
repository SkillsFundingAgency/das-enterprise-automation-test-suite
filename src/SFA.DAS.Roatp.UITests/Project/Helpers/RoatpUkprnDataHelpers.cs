using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class RoatpUkprnDataHelpers
    {
        private readonly Dictionary<string, List<KeyValuePair<string, string>>> _applyData;

        private const string emailkey = "emailkey";
        private const string ukprnkey = "ukprnkey";

        public RoatpUkprnDataHelpers()
        {
            _applyData = new Dictionary<string, List<KeyValuePair<string, string>>>();
            AddApplyDatahelpers();
            AddAdminDatahelpers();
        }

        public (string email, string ukprn) GetRoatpData(string key)
        {
            var keyValuePair = FindKeyValuePairs(key);
            var email = keyValuePair.First(x => x.Key == emailkey).Value;
            var ukprn = keyValuePair.First(x => x.Key == ukprnkey).Value;
            return (email, ukprn);
        }

        private List<KeyValuePair<string, string>> FindKeyValuePairs(string key) => _applyData.TryGetValue(key, out var keyValuePair) ? keyValuePair : throw new KeyNotFoundException($"Can not find data for key {key}");

        private void AddAdminDatahelpers()
        {
            _applyData.Add("rpadnp01",
            new List<KeyValuePair<string, string>>
            {
                   new KeyValuePair<string, string>(emailkey, ""),
                   new KeyValuePair<string, string>(ukprnkey, "10023959"),
            });
        }

        private void AddApplyDatahelpers()
        {
            _applyData.Add("rppj01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+C4@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10033140"),
                });
            _applyData.Add("rppj02",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+C7@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10048867"),
                });
            _applyData.Add("rppj03",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+C8@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10064416"),
                });
            _applyData.Add("rptc01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+B2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10062499"),
                });
            _applyData.Add("rpe2e01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+roatp2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10047117"),
                });
            _applyData.Add("rpe2e02",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+employer@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10061310"),
                });
            _applyData.Add("rpe2e03",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+supporting@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10083833"),
                });
            _applyData.Add("rps101",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D1@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10022702"),
                });
            _applyData.Add("rps102",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10048654"),
                });
            _applyData.Add("rps103",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D3@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10063781"),
                });
            _applyData.Add("rps104",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D4@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10026709"),
                });
            _applyData.Add("rps105",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D5@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10019873"),
                });
            _applyData.Add("rps106",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D6@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10010596"),
                });
            _applyData.Add("rps107",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D7@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10056340"),
                });
            _applyData.Add("rps108",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D8@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10057614"),
                });
        }
    }
}
