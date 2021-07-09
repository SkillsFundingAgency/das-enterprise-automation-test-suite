using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    internal static class TestDataCleanUpEmailsInUse
    {
        private static readonly List<string> _emails = new List<string>() { "'1'" };

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
