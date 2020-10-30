using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpFullE2EUkprnDataHelpers : RoatpUkprnDataHelpers
    {
        public RoatpFullE2EUkprnDataHelpers() : base() => AddE2EDatahelpers();

        public (string email, string providername, string ukprn) GetRoatpE2EData(string key) => GetData(FindKeyValuePairs(_e2eData, key), emailkey, providernamekey, ukprnkey);

        private void AddE2EDatahelpers()
        {
            _e2eData.Add("rpadendtoend01",
            new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+NewDemo@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "SIMPLY CREATING CHANGE LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10082167"),
                });
        }
    }
}
