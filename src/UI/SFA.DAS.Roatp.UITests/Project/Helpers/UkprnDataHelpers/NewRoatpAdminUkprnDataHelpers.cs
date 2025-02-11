namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class NewRoatpAdminUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public NewRoatpAdminUkprnDataHelpers() : base() => AddAdminDatahelpers();

        public (string email, string providername, string ukprn) GetNewRoatpAdminData(string key) => GetData(key, emailkey, providernamekey, ukprnkey);

        private void AddAdminDatahelpers()
        {
            _data.Add("rpadgw01",
              [
                    new(emailkey, "sudhakar.chinoor+rpadgw01@digital.education.gov.uk"),
                  new(providernamekey, "PARAGON TRAINING AND CONSULTING LIMITED"),
                  new(ukprnkey, "10065592"),
              ]); //rpe2e01
            _data.Add("rpadgw02",
            [
                    new(emailkey, "sudhakar.chinoor+rpadgw02@digital.education.gov.uk"),
                new(providernamekey, "WOODLANDS SPEAKS"),
                new(ukprnkey, "10065665"),
            ]); //rpe2e02
            _data.Add("rpadgw03",
           [
                    new(emailkey, "sudhakar.chinoor+rpadgw03@digital.education.gov.uk"),
               new(providernamekey, "JOHN MICHAEL PLANT"),
               new(ukprnkey, "10066541"),
           ]); //rpe2e03
            _data.Add("rpadgw04",
             [
                    new(emailkey, "sudhakar.chinoor+rpadgw04@digital.education.gov.uk"),
                 new(providernamekey, "FIT FOR SPORT LIMITED"),
                 new(ukprnkey, "10030570"),
             ]);//rpe2e01
            _data.Add("rpadgw05",
           [
                    new(emailkey, "sudhakar.chinoor+rpadgw05@digital.education.gov.uk"),
               new(providernamekey, "TRIRATNA SOUTHAMPTON"),
               new(ukprnkey, "10002617"),
           ]);//rpe2e02
            _data.Add("rpadgw06",
          [
                    new(emailkey, "sudhakar.chinoor+rpadgw06@digital.education.gov.uk"),
              new(providernamekey, "NIOMI SAMANTHA JOSEPH"),
              new(ukprnkey, "10066540"),
          ]); //rpe2e03
            _data.Add("rpadgw07",
           [
                    new(emailkey, "sudhakar.chinoor+rpadgw07@digital.education.gov.uk"),
               new(providernamekey, "JO INGHAM"),
               new(ukprnkey, "10040377"),
           ]); //rpe2e03
            _data.Add("rpadfha01",
             [
                    new(emailkey, "sudhakar.chinoor+rpadfha01@digital.education.gov.uk"),
                 new(providernamekey, "HENRI BAPTISTE"),
                 new(ukprnkey, "10054031"),
             ]); //rpe2e03, rpadgw03
            _data.Add("rpadfha02",
            [
                    new(emailkey, "sudhakar.chinoor+rpadfha02@digital.education.gov.uk"),
                new(providernamekey, "CHURCHILL COLLEGE IN THE UNIVERSITY OF CAMBRIDGE"),
                new(ukprnkey, "10056258"),
            ]); //rpe2e02, rpadgw02
            _data.Add("rpadas01",
            [
                    new(emailkey, "sudhakar.chinoor+rpadas01@digital.education.gov.uk"),
                new(providernamekey, "7TAO ENGINEERING UK LIMITED"),
                new(ukprnkey, "10082318"),
            ]);//rpe2e01, rpadgw01
            _data.Add("rpadas02",
            [
                    new(emailkey, "sudhakar.chinoor+rpadas02@digital.education.gov.uk"),
                new(providernamekey, "BEDAZZLE PROJECTS"),
                new(ukprnkey, "10068209"),
            ]);//rpe2e02, rpadgw02
            _data.Add("rpadas03",
            [
                    new(emailkey, "sudhakar.chinoor+rpadas03@digital.education.gov.uk"),
                new(providernamekey, "ARTHUR MUREVERWI"),
                new(ukprnkey, "10028295"),

            ]);//rpe2e03, rpadgw03
            _data.Add("rpadmod01",
           [
                    new(emailkey, "sudhakar.chinoor+rpadmod01@digital.education.gov.uk"),
               new(providernamekey, "EASY MANAGEMENT OF AGGRESSION LIMITED"),
               new(ukprnkey, "10008214"),
           ]);//rpe2e01, rpadgw01, rpadas01
            _data.Add("rpadmod02",
            [
                    new(emailkey, "sudhakar.chinoor+rpadmod02@digital.education.gov.uk"),
                new(providernamekey, "FORMISSION LTD"),
                new(ukprnkey, "10038763"),
            ]);//rpe2e02, rpadgw02, rpadas02
            _data.Add("rpadmod03",
            [
                   new(emailkey, "sudhakar.chinoor+rpadmod03@digital.education.gov.uk"),
                new(providernamekey, "LORNA BAIN"),
                new(ukprnkey, "10041478"),
            ]);//rpe2e03, rpadgw03, rpadas03
            _data.Add("rpadcla01",
            [
                    new(emailkey, "sudhakar.chinoor+rpadcla01@digital.education.gov.uk"),
                new(providernamekey, "ALTURA LEARNING UNITED KINGDOM LIMITED"),
                new(ukprnkey, "10082168"),
            ]);//rpe2e01, rpadgw01, rpadas01, moderation (fail every section and ask for clarification)
            _data.Add("rpadcla02",
            [
                    new(emailkey, "sudhakar.chinoor+rpadcla02@digital.education.gov.uk"),
                new(providernamekey, "ONE VISION MEDIA"),
                new(ukprnkey, "10063154"),
            ]);//rpe2e02, rpadgw02, rpadas02, moderation (fail few section and ask for clarification)
            _data.Add("rpadoutcome01",
            [
                   new(emailkey, "sudhakar.chinoor+rpadoutcome01@digital.education.gov.uk"),
                new(providernamekey, "FYLO LTD."),
                new(ukprnkey, "10067908"),
            ]);//rpe2e01, rpadgw01, rpadas01, rpadmod01
            _data.Add("rpadoutcomeappeals01",
            [
                   new(emailkey, "sudhakar.chinoor+rpadoutcomeappeals01@digital.education.gov.uk"),
                new(providernamekey, "COUNTY BUSINESS SCHOOL LIMITED"),
                new(ukprnkey, "10067972"),
            ]);//rpe2e01, rpadgw01, rpadas01, rpadmod01
            _data.Add("rpadallowlist01",
           [
                   new(emailkey, "sudhakar.chinoor+rpallowlist01@digital.education.gov.uk"),
               new(providernamekey, "TEST"),
               new(ukprnkey, "10001234"),
           ]);
            _data.Add("rpadgatewayfailappeals01",
             [
                    new(emailkey, "sudhakar.chinoor+GatewayFailAppeal@digital.education.gov.uk"),
                 new(providernamekey, "DONCASTER ROVERS FOOTBALL CLUB LIMITED"),
                 new(ukprnkey, "10030581"),
             ]);//rpe2e01 ,rpadgw04
            _data.Add("rpadgatewayrejectreapplications01",
            [
                    new(emailkey, "sudhakar.chinoor+GatewayRejectReapplication@digital.education.gov.uk"),
                new(providernamekey, "DORSET COUNTY FOOTBALL ASSOCIATION LIMITED"),
                new(ukprnkey, "10030587"),
            ]);//rpe2e01 ,rpadgw05
        }
    }
}
