namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class RoatpApplyTestDataPrepDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public RoatpApplyTestDataPrepDataHelpers() : base() => AddApplyPerfTestData();

        public (string email, string ukprn) GetRoatpAppplyData(string key) => GetData(key, emailkey, ukprnkey);

        private void AddApplyPerfTestData()
        {
            _data.Add("rptestdataperfe2e01",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165144@digital.education.gov.uk"),
                new(ukprnkey, "10052881"),
            ]);
            _data.Add("rptestdataperfe2e02",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165200@digital.education.gov.uk"),
                new(ukprnkey, "10052888"),
            ]);
            _data.Add("rptestdataperfe2e03",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165243@digital.education.gov.uk"),
                new(ukprnkey, "10052932"),
            ]);
            _data.Add("rptestdataperfe2e04",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165229@digital.education.gov.uk"),
                new(ukprnkey, "10052934"),
            ]);
            _data.Add("rptestdataperfe2e05",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165322@digital.education.gov.uk"),
                new(ukprnkey, "10052937"),
            ]);
            _data.Add("rptestdataperfe2e06",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165350@digital.education.gov.uk"),
                new(ukprnkey, "10049261"),
            ]);
            _data.Add("rptestdataperfe2e07",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165336@digital.education.gov.uk"),
                new(ukprnkey, "10053205"),
            ]);
            _data.Add("rptestdataperfe2e08",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165309@digital.education.gov.uk"),
                new(ukprnkey, "10053208"),
            ]);
            _data.Add("rptestdataperfe2e09",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165215@digital.education.gov.uk"),
                new(ukprnkey, "10053332"),
            ]);
            _data.Add("rptestdataperfe2e10",
            [
                    new(emailkey, "sudhakar.chinoor+perftest20Nov2020_165256@digital.education.gov.uk"),
                new(ukprnkey, "10049196"),
            ]);
        }
    }
}
