using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class RoatpApplyUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public RoatpApplyUkprnDataHelpers() : base() => AddApplyDatahelpers();

        public (string email, string ukprn) GetRoatpAppplyData(string key) => GetData(key, emailkey, ukprnkey);
      
        private void AddApplyDatahelpers()
        {
            _data.Add("rpse01",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+SE1@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10066722"),
               });
            _data.Add("rpse02",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "umakanth.gangaraju+SE2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10058122"),
               });
            _data.Add("rpuhp01",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+U1@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10022137"),
               });
            _data.Add("rppj01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+C4@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10033140"),
                });
            _data.Add("rppj02",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+C7@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10048867"),
                });
            _data.Add("rppj03",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+C8@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10064416"),
                });
            _data.Add("rptc01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+B2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10062499"),
                });
            _data.Add("rpe2e01",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+roatp2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10047117"),
                });
            _data.Add("rpe2e02",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+employer@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10061310"),
               });
            _data.Add("rpe2e03",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+supporting@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10083833"),
                });
            _data.Add("rpe2e04",
              new List<KeyValuePair<string, string>>
              {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+mainCC@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10004708"),
              });
            _data.Add("rpe2e05",
             new List<KeyValuePair<string, string>>
             {
                    new KeyValuePair<string, string>(emailkey, "umakanth.gangaraju+FHAExempt@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10046095"),
             });
            _data.Add("rpe2e06",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+GOVT@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10052113"),
            });
            _data.Add("rps101",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D1@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10022702"),
                });
            _data.Add("rps102",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D2@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10048654"),
                });
            _data.Add("rps103",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D3@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10063781"),
                });
            _data.Add("rps104",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D4@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10026709"),
                });
            _data.Add("rps105",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D5@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10019873"),
                });
            _data.Add("rps106",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D6@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10010596"),
                });
            _data.Add("rps107",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D7@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10057661"),
                });
            _data.Add("rps108",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D8@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10057614"),
                });
            _data.Add("rps109",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D9@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10027640"),
                });
            _data.Add("rps110",
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D10@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10029227"),
                });
            _data.Add("rps111",
               new List<KeyValuePair<string, string>>
               {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+D11@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10029129"),
               });
            _data.Add("rpcr01",
              new List<KeyValuePair<string, string>>
              {
                    new KeyValuePair<string, string>(emailkey, "sudhakar.chinoor+CR01@digital.education.gov.uk"),
                    new KeyValuePair<string, string>(ukprnkey, "10047260"),
              });
        }
    }
}
