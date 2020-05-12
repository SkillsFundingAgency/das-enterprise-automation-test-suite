using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminUkprnDataHelpers : RoatpUkprnDataHelpers
    {
        public RoatpAdminUkprnDataHelpers() : base() => AddAdminDatahelpers();

        public (string providername, string ukprn) GetRoatpAdminData(string key) => GetAdminData(FindKeyValuePairs(_adminData, key), providernamekey, ukprnkey);

        private void AddAdminDatahelpers()
        {
            _adminData.Add("rpadsp01",
               new List<KeyValuePair<string, string>>
               {
                   new KeyValuePair<string, string>(providernamekey, "BARNARDO'S"),
                   new KeyValuePair<string, string>(ukprnkey, "10000532"),
               });
            _adminData.Add("rpadup01",
               new List<KeyValuePair<string, string>>
               {
                   new KeyValuePair<string, string>(providernamekey, "PHILIPS HAIR SALONS LIMITED"),
                   new KeyValuePair<string, string>(ukprnkey, "10005089"),
               });
            _adminData.Add("rpadnp01",
               new List<KeyValuePair<string, string>>
               {
                   new KeyValuePair<string, string>(providernamekey, "BUSINESS CONTINUITY TRAINING LIMITED"),
                   new KeyValuePair<string, string>(ukprnkey, "10023959"),
               });
            _adminData.Add("rpadnp02",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(providernamekey, "LOCUS INTERNATIONAL LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10036913"),
               });
            _adminData.Add("rpadnp03",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(providernamekey, "OLMEC"),
                    new KeyValuePair<string, string>(ukprnkey, "10033872"),
               });
        }
    }
}
