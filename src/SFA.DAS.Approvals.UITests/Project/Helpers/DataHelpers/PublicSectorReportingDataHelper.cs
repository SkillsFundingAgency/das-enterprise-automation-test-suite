using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class PublicSectorReportingDataHelper
    {
        public PublicSectorReportingDataHelper()
        {
            NoofEmployees2021 = RandomDataGenerator.GenerateRandomWholeNumber(2);
            NoofEmployees2022 = RandomDataGenerator.GenerateRandomWholeNumber(3);
            NoofNewEmployees = (int.Parse(NoofEmployees2022) - int.Parse(NoofEmployees2021)).ToString();

            NoofApprentices2021 = RandomDataGenerator.GenerateRandomWholeNumber(1);
            NoofApprentices2022 = RandomDataGenerator.GenerateRandomWholeNumber(2);
            NoofNewApprentices = (int.Parse(NoofEmployees2022) - int.Parse(NoofEmployees2021)).ToString();

            NoofFullTimeEmployees = RandomDataGenerator.GenerateRandomWholeNumber(2);

            EmployerActions = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            EmployerChallenges = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            EmployerPlanning = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            EmployerComments = RandomDataGenerator.GenerateRandomAlphabeticString(20);
        }

        internal string EmployerActions { get; }
        internal string EmployerChallenges { get; }
        internal string EmployerPlanning { get; }
        internal string EmployerComments { get; }
        internal string NoofEmployees2021 { get; }
        internal string NoofEmployees2022 { get; }
        internal string NoofNewEmployees { get; }
        internal string NoofApprentices2021 { get; }
        internal string NoofApprentices2022 { get; }
        internal string NoofNewApprentices { get; }
        internal string NoofFullTimeEmployees { get; }
    }
}
