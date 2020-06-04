using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Helpers
{
    public static class FetchProviderFeedbackData
    {
        private static readonly object _object = new object();

        private static readonly List<string> UniqueSurveyCodes = new List<string>(); 

        internal static string UniqueSurveyCode(string connectionString)
        {
            lock (_object)
            {
                string exclude = string.Empty;

                if (UniqueSurveyCodes.Any())
                {
                    string usedcodes = string.Empty;
                    foreach (var item in UniqueSurveyCodes)
                    {
                        usedcodes += $"'{item}',";
                    }
                    usedcodes = usedcodes.Trim(',');

                    exclude = $"[UniqueSurveyCode] not in ({usedcodes}) and";
                }

                var queryToExecute = $"SELECT TOP (1) [UniqueSurveyCode] FROM [dbo].[vw_EmployerSurveyHistoryComplete] where {exclude} CodeBurntDate is null order by LastReminderSentDate desc";

                var code = Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0]);

                UniqueSurveyCodes.Add(code);

                return code;
            }
        }
    }
}
