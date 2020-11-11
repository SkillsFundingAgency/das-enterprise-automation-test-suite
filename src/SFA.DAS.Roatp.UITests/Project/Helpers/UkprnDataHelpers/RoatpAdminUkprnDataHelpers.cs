using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class RoatpAdminUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public RoatpAdminUkprnDataHelpers() : base() => AddAdminDatahelpers();

        public (string providername, string ukprn) GetRoatpAdminData(string key) => GetData(FindKeyValuePairs(_data, key), providernamekey, ukprnkey);

        private void AddAdminDatahelpers()
        {
            _data.Add("rpadsp01",
               new List<KeyValuePair<string, string>>
               {
                   new KeyValuePair<string, string>(providernamekey, "BARNARDO'S"),
                   new KeyValuePair<string, string>(ukprnkey, "10000532"),
               });
            _data.Add("rpadup01",
               new List<KeyValuePair<string, string>>
               {
                   new KeyValuePair<string, string>(providernamekey, "PHILIPS HAIR SALONS LIMITED"),
                   new KeyValuePair<string, string>(ukprnkey, "10005089"),
               });
            _data.Add("rpadnp01",
               new List<KeyValuePair<string, string>>
               {
                   new KeyValuePair<string, string>(providernamekey, "BUSINESS CONTINUITY TRAINING LIMITED"),
                   new KeyValuePair<string, string>(ukprnkey, "10023959"),
               });
            _data.Add("rpadnp02",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(providernamekey, "LOCUS INTERNATIONAL LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10036913"),
               });
            _data.Add("rpadnp03",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(providernamekey, "OLMEC"),
                    new KeyValuePair<string, string>(ukprnkey, "10033872"),
               });
            _data.Add("rpadgw01",
              new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(providernamekey, "PARAGON TRAINING AND CONSULTING LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10065592"),
             });
            _data.Add("rpadgw02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "WOODLANDS SPEAKS"),
                    new KeyValuePair<string, string>(ukprnkey, "10065665"),
            });
            _data.Add("rpadgw03",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(providernamekey, "JOHN MICHAEL PLANT"),
                    new KeyValuePair<string, string>(ukprnkey, "10066541"),
           });
            _data.Add("rpadfha01",
             new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(providernamekey, "HENRI BAPTISTE"),
                    new KeyValuePair<string, string>(ukprnkey, "10054031"),
             });
            _data.Add("rpadas01",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "7TAO ENGINEERING UK LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10082318"),
            });
            _data.Add("rpadas02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "ARTHUR MUREVERWI"),
                    new KeyValuePair<string, string>(ukprnkey, "10028295"),
            });
            _data.Add("rpadas03",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "SHOCKOUT ACADEMY"),
                    new KeyValuePair<string, string>(ukprnkey, "10065987"),
            });
            _data.Add("rpadmod01",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(providernamekey, "EASY MANAGEMENT OF AGGRESSION LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10008214"),
           });
            _data.Add("rpadmod02",
            new List<KeyValuePair<string, string>>
            {
                   new KeyValuePair<string, string>(providernamekey, "LORNA BAIN"),
                   new KeyValuePair<string, string>(ukprnkey, "10041478"),
            });
            _data.Add("rpadmod03",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "FORMISSION LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10038763"),
            });
            _data.Add("rpadcla01",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "ALTURA LEARNING UNITED KINGDOM LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10082168"),
            });
            _data.Add("rpadcla02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "ONE VISION MEDIA"),
                    new KeyValuePair<string, string>(ukprnkey, "10063154"),
            });
        }
    }
}
