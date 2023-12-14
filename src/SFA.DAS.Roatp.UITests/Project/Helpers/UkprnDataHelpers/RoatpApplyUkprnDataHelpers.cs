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
               [
                    new(emailkey, "sudhakar.chinoor+SE1@digital.education.gov.uk"),
                    new(ukprnkey, "10066722"),
               ]);
            _data.Add("rpse02",
               [
                    new(emailkey, "umakanth.gangaraju+SE2@digital.education.gov.uk"),
                    new(ukprnkey, "10058122"),
               ]);
            _data.Add("rpuhp01",
               [
                    new(emailkey, "sudhakar.chinoor+U1@digital.education.gov.uk"),
                    new(ukprnkey, "10022137"),
               ]);
            _data.Add("rppj01",
                [
                    new(emailkey, "sudhakar.chinoor+C4@digital.education.gov.uk"),
                    new(ukprnkey, "10033140"),
                ]);
            _data.Add("rppj02",
                [
                    new(emailkey, "sudhakar.chinoor+C7@digital.education.gov.uk"),
                    new(ukprnkey, "10048867"),
                ]);
            _data.Add("rppj03",
                [
                    new(emailkey, "sudhakar.chinoor+C8@digital.education.gov.uk"),
                    new(ukprnkey, "10064416"),
                ]);
            _data.Add("rptc01",
                [
                    new(emailkey, "sudhakar.chinoor+B2@digital.education.gov.uk"),
                    new(ukprnkey, "10062499"),
                ]);
            _data.Add("rpe2e07",
            [
                    new(emailkey, "sudhakar.chinoor+SupportingNew@digital.education.gov.uk"),
                    new(ukprnkey, "10083878"),
            ]);
            _data.Add("rpe2e08",
            [
                    new(emailkey, "sudhakar.chinoor+MainNew@digital.education.gov.uk"),
                    new(ukprnkey, "10047196"),
           ]);
            _data.Add("rpe2e09",
           [
                    new(emailkey, "sudhakar.chinoor+EmployerNew@digital.education.gov.uk"),
                    new(ukprnkey, "10056078"),
           ]);
            _data.Add("rps101",
                [
                    new(emailkey, "sudhakar.chinoor+D1@digital.education.gov.uk"),
                    new(ukprnkey, "10022702"),
                ]);
            _data.Add("rps102",
                [
                    new(emailkey, "sudhakar.chinoor+D2@digital.education.gov.uk"),
                    new(ukprnkey, "10048894"),
                ]);
            _data.Add("rps103",
                [
                    new(emailkey, "sudhakar.chinoor+D3@digital.education.gov.uk"),
                    new(ukprnkey, "10063781"),
                ]);
            _data.Add("rps104",
                [
                    new(emailkey, "sudhakar.chinoor+D4@digital.education.gov.uk"),
                    new(ukprnkey, "10026709"),
                ]);
            _data.Add("rps105",
                [
                    new(emailkey, "sudhakar.chinoor+D5@digital.education.gov.uk"),
                    new(ukprnkey, "10019873"),
                ]);
            _data.Add("rps106",
                [
                    new(emailkey, "sudhakar.chinoor+D6@digital.education.gov.uk"),
                    new(ukprnkey, "10010596"),
                ]);
            _data.Add("rps107",
                [
                    new(emailkey, "sudhakar.chinoor+D7@digital.education.gov.uk"),
                    new(ukprnkey, "10057661"),
                ]);
            _data.Add("rps108",
                [
                    new(emailkey, "sudhakar.chinoor+D8@digital.education.gov.uk"),
                    new(ukprnkey, "10057614"),
                ]);
            _data.Add("rps109",
                [
                    new(emailkey, "sudhakar.chinoor+D9@digital.education.gov.uk"),
                    new(ukprnkey, "10027640"),
                ]);
            _data.Add("rps110",
                [
                    new(emailkey, "sudhakar.chinoor+D10@digital.education.gov.uk"),
                    new(ukprnkey, "10029227"),
                ]);
            _data.Add("rps111",
               [
                    new(emailkey, "sudhakar.chinoor+D11@digital.education.gov.uk"),
                    new(ukprnkey, "10029129"),
               ]);
            _data.Add("rpcr01",
              [
                    new(emailkey, "sudhakar.chinoor+CR01@digital.education.gov.uk"),
                    new(ukprnkey, "10047260"),
              ]);
        }
    }
}
