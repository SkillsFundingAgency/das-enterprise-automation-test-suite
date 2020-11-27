using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class NewRoatpAdminUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public NewRoatpAdminUkprnDataHelpers() : base() => AddAdminDatahelpers();

        public (string email, string providername, string ukprn) GetNewRoatpAdminData(string key) => GetData(key, emailkey, providernamekey, ukprnkey);

        private void AddAdminDatahelpers()
        {
            _data.Add("rpadgw01",
              new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+rpadgw01@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "PARAGON TRAINING AND CONSULTING LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10065592"),
             }); //rpe2e01
            _data.Add("rpadgw02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+rpadgw02@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "WOODLANDS SPEAKS"),
                    new KeyValuePair<string, string>(ukprnkey, "10065665"),
            }); //rpe2e02
            _data.Add("rpadgw03",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+rpadgw03@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "JOHN MICHAEL PLANT"),
                    new KeyValuePair<string, string>(ukprnkey, "10066541"),
           }); //rpe2e03
            _data.Add("rpadfha01",
             new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+rpadfha01@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "HENRI BAPTISTE"),
                    new KeyValuePair<string, string>(ukprnkey, "10054031"),
             }); //rpe2e03, rpadgw03
            _data.Add("rpadfha02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+rpadfha02@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "CHURCHILL COLLEGE IN THE UNIVERSITY OF CAMBRIDGE"),
                    new KeyValuePair<string, string>(ukprnkey, "10056258"),
            }); //rpe2e02, rpadgw02
            _data.Add("rpadas01",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey,"sudhakar.chinoor+rpadas01@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "7TAO ENGINEERING UK LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10082318"),
            });//rpe2e01, rpadgw01
            _data.Add("rpadas02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey,"sudhakar.chinoor+rpadas02@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "SHOCKOUT ACADEMY"),
                    new KeyValuePair<string, string>(ukprnkey, "10065987"),
            });//rpe2e02, rpadgw02
            _data.Add("rpadas03",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey,"sudhakar.chinoor+rpadas03@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(providernamekey, "ARTHUR MUREVERWI"),
                    new KeyValuePair<string, string>(ukprnkey, "10028295"),

            });//rpe2e03, rpadgw03
            _data.Add("rpadmod01",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(providernamekey, "EASY MANAGEMENT OF AGGRESSION LIMITED"),
                    new KeyValuePair<string, string>(ukprnkey, "10008214"),
           });//rpe2e01, rpadgw01, rpadas01
            _data.Add("rpadmod02",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(providernamekey, "FORMISSION LTD"),
                    new KeyValuePair<string, string>(ukprnkey, "10038763"),
            });//rpe2e02, rpadgw02, rpadas02
            _data.Add("rpadmod03",
            new List<KeyValuePair<string, string>>
            {
                   new KeyValuePair<string, string>(providernamekey, "LORNA BAIN"),
                   new KeyValuePair<string, string>(ukprnkey, "10041478"),
            });//rpe2e03, rpadgw03, rpadas03
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
