using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class ApprenticeRedundancyDataHelper : RandomElementHelper
    {
        public ApprenticeRedundancyDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            Months = randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, 11);
            Years = randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, 9);
            LongText = randomDataGenerator.GenerateRandomAlphabeticString(500);

        }

        public DateTime Dob(int x) => DateTime.Now.AddYears(-20 + x);
        public string FullName => "Apprentice Smith";
        public string JobRole => "Employee";
        public string Email => "test.demo@digital.education.gov.uk";
        public string Postcode => "CV22 4NX";
        public string PreviousApprenticeshipTraining = "Information Technology";
        public string Location = "Coventry";
        public string Employer = "Apprentice Digital Education";
        public string TrainingProvider = "TEST Regression";
        public int Months { get; }
        public string ContactNumber = "+4409839867 ext (1234) 07809839867 ext (12343232)";
        public int Years { get; }
        public string LongText { get; }
        public string OrganisationName => "Regression Test";
        public string Website => "www.Regressiontest.com";
        public string GetFromdate => "2020-07-01";
    }
}
