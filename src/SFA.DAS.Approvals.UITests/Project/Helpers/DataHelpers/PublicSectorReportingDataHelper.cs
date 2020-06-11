using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class PublicSectorReportingDataHelper : RandomElementHelper
    {
        public PublicSectorReportingDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            NoofEmployees2019 = randomDataGenerator.GenerateRandomWholeNumber(2);
            NoofEmployees2020 = randomDataGenerator.GenerateRandomWholeNumber(3);
            NoofNewEmployees = (int.Parse(NoofEmployees2020) - int.Parse(NoofEmployees2019)).ToString();

            NoofApprentices2019 = randomDataGenerator.GenerateRandomWholeNumber(1);
            NoofApprentices2020 = randomDataGenerator.GenerateRandomWholeNumber(2);
            NoofNewApprentices = (int.Parse(NoofEmployees2020) - int.Parse(NoofEmployees2019)).ToString();

            NoofFullTimeEmployees = randomDataGenerator.GenerateRandomWholeNumber(2);

            EmployerActions = randomDataGenerator.GenerateRandomAlphabeticString(20);
            EmployerChallenges = randomDataGenerator.GenerateRandomAlphabeticString(20);
            EmployerPlanning = randomDataGenerator.GenerateRandomAlphabeticString(20);
            EmployerComments = randomDataGenerator.GenerateRandomAlphabeticString(20);
        }

        internal string EmployerActions { get; }
        internal string EmployerChallenges { get; }
        internal string EmployerPlanning { get; }
        internal string EmployerComments { get; }
        internal string NoofEmployees2019 { get; }
        internal string NoofEmployees2020 { get; }
        internal string NoofNewEmployees { get; }
        internal string NoofApprentices2019 { get; }
        internal string NoofApprentices2020 { get; }
        internal string NoofNewApprentices { get; }
        internal string NoofFullTimeEmployees { get; }
    }
}
