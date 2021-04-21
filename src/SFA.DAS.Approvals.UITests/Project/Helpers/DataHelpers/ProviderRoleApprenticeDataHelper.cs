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
                    new KeyValuePair<string, string>(firstname, "User45"),
                    new KeyValuePair<string, string>(lastname, "Test"),
            });
            _data.Add("ChangesPendingApprentice",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "User27"),
                    new KeyValuePair<string, string>(lastname, "Test"),
            });
            _data.Add("ILRDataMismatchApprentice",
            new List<KeyValuePair<string, string>>
            {
                    new KeyValuePair<string, string>(firstname, "F_HJNgDpRVwT"),
                    new KeyValuePair<string, string>(lastname, "L_vicyMjKphr"),
            });
            _data.Add("LiveApprentice",
           new List<KeyValuePair<string, string>>
           {
                    new KeyValuePair<string, string>(firstname, "David"),
                    new KeyValuePair<string, string>(lastname, "Clarke"),
           });
            _data.Add("StoppedApprentice",
          new List<KeyValuePair<string, string>>
          {
                    new KeyValuePair<string, string>(firstname, "F_GEWeMBRBGL"),
                    new KeyValuePair<string, string>(lastname, "L_GLwVYpKCmU"),
          });
        }

    }
}
