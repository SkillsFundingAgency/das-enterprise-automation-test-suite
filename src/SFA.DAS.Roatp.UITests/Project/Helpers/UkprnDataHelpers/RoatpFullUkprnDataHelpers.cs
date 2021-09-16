using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class RoatpFullUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public RoatpFullUkprnDataHelpers() : base() => AddE2EDatahelpers();

        public (string email, string providername, string ukprn) GetRoatpE2EData(string key) => GetData(key, emailkey, providernamekey, ukprnkey);

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
            _data.Add("rpendtoend02apply",
            new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+E2E02@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "METROPOLITAN TABERNACLE"),
                    new KeyValuePair<string, string>(ukprnkey, "10068436"),
             });
            _data.Add("rpexistingprovider01",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+roatp2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "CHRYSALIS NOT FOR PROFIT LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10047121"),
               });
            _data.Add("rpexistingprovider02",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+employer@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "GATESHEAD VISIBLE ETHNIC MINORITIES SUPPORT GROUP"),
                    new KeyValuePair<string, string>(ukprnkey, "10061310"),
               });
            _data.Add("rpexistingprovider03",
             new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+supporting@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "COLEMAN TRAINING & CONSULTANCY"),
                    new KeyValuePair<string, string>(ukprnkey, "10083833"),
              }); 
            _data.Add("rpexistingprovider04",
              new List<KeyValuePair<string, string>>
              {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+mainCC@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "NORTH ORMESBY NEIGHBOURHOOD DEVELOPMENT TRUST LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10004708"),
              });
            _data.Add("rpexistingprovider05",
             new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(emailkey, "umakanth.gangaraju+FHAExempt@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "TALENTINO LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10046095"),
             });
            _data.Add("rpexistingprovider06",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+GOVT@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "WILLIAMSTON PRIMARY SCHOOL"),
                    new KeyValuePair<string, string>(ukprnkey, "10052113"),
            });
        }
    }
}
