using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ApplyDataHelpers
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly Dictionary<string, List<KeyValuePair<string, string>>> _applyDatas;
        
        private const string emailkey = "emailkey";
        private const string ukprnkey = "ukprnkey";

        internal string Rpe2e01 => "rpe2e01";

        public ApplyDataHelpers(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            _applyDatas = new Dictionary<string, List<KeyValuePair<string, string>>>();
            AddApplyDatahelpers();
        }

        public (string email, string ukprn) GetApplyData(string key)
        {
            var keyValuePair = _applyDatas.GetValueOrDefault(key);
            var email = keyValuePair.First(x => x.Key == emailkey).Value;
            var ukprn = keyValuePair.First(x => x.Key == ukprnkey).Value;
            return (email, ukprn);
        }

        private void AddApplyDatahelpers()
        {
            _applyDatas.Add(Rpe2e01, 
                new List<KeyValuePair<string, string>> 
                { 
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+roatp2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10037678"),
                });
        }
    }
}
