using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    internal static class TestDataCleanUpEmailsInUse
    {
        private static readonly List<string> _emails = new List<string>() 
        { "'first111@test.com'", 
          "'LE_Test_101_18Aug2020_18453894282@mailinator.com'",
          "'HJDemoTestPP@mailinator.com'",
          "'LE_Test_101_10Dec2020_20093533414@mailinator.com'",
          "'LE_Test_101_01Dec2020_14273181086@mailinator.com'",
          "'LE_Test_101_01Dec2020_14231043754@mailinator.com'",
          "'LE_Test_101_01Dec2020_14062448752@mailinator.com'",
          "'LE_Test_101_01Dec2020_13591940469@mailinator.com'",
          "'LE_Test_101_01Dec2020_13165726403@mailinator.com'",
          "'LE_Test_101_01Dec2020_13091928413@mailinator.com'",
          "'LE_Test_101_01Dec2020_13030055901@mailinator.com'",
          "'LE_Test_101_30Nov2020_22564021583@mailinator.com'"};

        internal static string GetInUseEmails() { lock (_emails) { return string.Join(",", _emails); } }

        internal static void AddInUseEmails(List<string> emails)
        {
            lock (_emails)
            {
                foreach (var email in emails)
                {
                    _emails.Add($"'{email}'");
                }
            }
        }
    }
}
