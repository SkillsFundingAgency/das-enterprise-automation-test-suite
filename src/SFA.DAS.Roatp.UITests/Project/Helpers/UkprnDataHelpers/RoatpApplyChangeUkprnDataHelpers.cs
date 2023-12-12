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
                    new(emailkey, "sudhakar.chinoor+ChangeUKPRNJourney@digital.education.gov.uk"),
                    new(ukprnkey, "10084176"),
                    new(newukprnkey, "10084177")
                });
        }
    }
}
