namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ProviderRoleApprenticeDataHelper : ProviderRoleApprenticeBaseDataHelper
    {
        public ProviderRoleApprenticeDataHelper() : base() => AddProviderRoleApprenticeTestData();

        public (string firstname, string lastname) GetProviderRoleApprenticeTestData(string key) => GetData(key, firstname, lastname);

        public void AddProviderRoleApprenticeTestData()
        {
            _data.Add("ChangesForReviewApprentice",
            [
                    new(firstname, "DoNotUse_TestData"),
                new(lastname, "ChangesForReviewApprentice"),
            ]);
            _data.Add("ChangesPendingApprentice",
            [
                    new(firstname, "DoNotUse_TestData"),
                new(lastname, "ChangesPendingApprentice"),
            ]);
            _data.Add("ILRDataMisMatchRequestDetails",
            [
                    new(firstname, "DoNotUse_TestData"),
                new(lastname, "ILRDataMisMatchRequestDetails"),
            ]);
            _data.Add("LiveApprentice",
           [
                    new(firstname, "DoNotUse_TestData"),
               new(lastname, "LiveApprentice"),
           ]);
            _data.Add("StoppedApprentice",
            [
                    new(firstname, "DoNotUse_TestData"),
                new(lastname, "StoppedApprentice"),
            ]);
            _data.Add("ILRDataMisMatchAskEmployerToFix",
            [
                    new(firstname, "DoNotUse_TestData"),
                new(lastname, "ILRDataMisMatchAskEmployerToFix"),
            ]);
        }
    }
}
