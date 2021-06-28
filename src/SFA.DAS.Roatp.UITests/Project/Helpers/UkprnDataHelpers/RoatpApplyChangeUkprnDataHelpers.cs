using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class RoatpApplyChangeUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public RoatpApplyChangeUkprnDataHelpers() : base() => AddApplyDatahelpers();

        public (string email, string ukprn, string newukprn) GetRoatpChangeUkprnAppplyData(string key) => GetData(key, emailkey, ukprnkey, newukprnkey);

        private void AddApplyDatahelpers()
        {
            _data.Add("rpchangeukprn01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+ChangeUKPRNJourney@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10084176"),
                    new KeyValuePair<string, string>(newukprnkey, "10084177")
                });
        }
    }
}
