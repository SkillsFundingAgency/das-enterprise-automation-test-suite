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
            _adminData.Add("rpadgw01",
              new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(providernamekey, "PARAGON TRAINING AND CONSULTING LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10065592"),
             });
            _adminData.Add("rpadgw02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "WOODLANDS SPEAKS"),
                    new KeyValuePair<string, string>(ukprnkey, "10065665"),
            });
            _adminData.Add("rpadgw03",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(providernamekey, "JOHN MICHAEL PLANT"),
                    new KeyValuePair<string, string>(ukprnkey, "10066541"),
           });
            _adminData.Add("rpadfha01",
             new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(providernamekey, "HENRI BAPTISTE"),
                    new KeyValuePair<string, string>(ukprnkey, "10054031"),
             });
            _adminData.Add("rpadas01",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "7TAO ENGINEERING UK LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10082318"),
            });
            _adminData.Add("rpadas02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "ARTHUR MUREVERWI"),
                    new KeyValuePair<string, string>(ukprnkey, "10028295"),
            });
            _adminData.Add("rpadas03",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "SHOCKOUT ACADEMY"),
                    new KeyValuePair<string, string>(ukprnkey, "10065987"),
            });
            _adminData.Add("rpadmod01",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(providernamekey, "EASY MANAGEMENT OF AGGRESSION LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10008214"),
           });
            _adminData.Add("rpadmod02",
            new List<KeyValuePair<string, string>>
            {
                   new KeyValuePair<string, string>(providernamekey, "LORNA BAIN"),
                   new KeyValuePair<string, string>(ukprnkey, "10041478"),
            });
            _adminData.Add("rpadmod03",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "FORMISSION LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10038763"),
            });
        _adminData.Add("rpadendtoend01",
        new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "SIMPLY CREATING CHANGE LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10082167"),
            });
        }
    }
}
