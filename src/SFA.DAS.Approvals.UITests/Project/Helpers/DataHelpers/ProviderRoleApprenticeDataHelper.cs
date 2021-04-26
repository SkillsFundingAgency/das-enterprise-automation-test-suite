using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ProviderRoleApprenticeDataHelper : ProviderRoleApprenticeBaseDataHelper
    {
        public ProviderRoleApprenticeDataHelper() : base() => AddProviderRoleApprenticeTestData();

        public (string firstname, string lastname) GetProviderRoleApprenticeTestData(string key) => GetData(key, firstname, lastname); 

        public void AddProviderRoleApprenticeTestData()
        {
            _data.Add("ChangesForReviewApprentice", 
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "DoNotUse_TestData"),
                    new KeyValuePair<string, string>(lastname, "ChangesForReviewApprentice"),
            });
            _data.Add("ChangesPendingApprentice",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "DoNotUse_TestData"),
                    new KeyValuePair<string, string>(lastname, "ChangesPendingApprentice"),
            });
            _data.Add("ILRDataMisMatchRequestDetails",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "DoNotUse_TestData"),
                    new KeyValuePair<string, string>(lastname, "ILRDataMisMatchRequestDetails"),
            });
            _data.Add("LiveApprentice",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(firstname, "DoNotUse_TestData"),
                    new KeyValuePair<string, string>(lastname, "LiveApprentice"),
           });
            _data.Add("StoppedApprentice",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "DoNotUse_TestData"),
                    new KeyValuePair<string, string>(lastname, "StoppedApprentice"),
            });
            _data.Add("ILRDataMisMatchAskEmployerToFix",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "DoNotUse_TestData"),
                    new KeyValuePair<string, string>(lastname, "ILRDataMisMatchAskEmployerToFix"),
            });
        }

    }
}
