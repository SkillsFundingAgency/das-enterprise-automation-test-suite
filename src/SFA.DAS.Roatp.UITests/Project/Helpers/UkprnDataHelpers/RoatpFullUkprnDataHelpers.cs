using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class RoatpFullUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public RoatpFullUkprnDataHelpers() : base() => AddE2EDatahelpers();

        public (string email, string providername, string ukprn) GetRoatpE2EData(string key) => GetData(FindKeyValuePairs(_data, key), emailkey, providernamekey, ukprnkey);

        private void AddE2EDatahelpers()
        {
            _data.Add("rpendtoend01apply",
            new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+NewDemo@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "SIMPLY CREATING CHANGE LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10082167"),
                });
            _data.Add("rpip01",
            new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+InProgressApplication@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "THE PAROCHIAL CHURCH COUNCIL OF THE ECCLESIASTICAL PARISH OF THE GOOD SHEPHERD"),
                    new KeyValuePair<string, string>(ukprnkey, "10065943"),
                });
        }
    }
}
