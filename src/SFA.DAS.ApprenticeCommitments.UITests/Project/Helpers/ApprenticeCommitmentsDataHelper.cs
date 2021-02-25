using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class ApprenticeCommitmentsDataHelper : ApprenticeCommitmentsApiDataHelper
    {
        public ApprenticeCommitmentsDataHelper(RandomDataGenerator randomDataGenerator)
        {
            ApprenticeFirstname = $"F_{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            ApprenticeLastname = $"L_{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            DateOfBirthDay = randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = randomDataGenerator.GenerateRandomDobYear();
            NationalInsuranceNumber = $"AB3{randomDataGenerator.GenerateRandomWholeNumber(4)}5C";
        }

        public string ApprenticeFirstname { get; }

        public string ApprenticeLastname { get;  }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string NationalInsuranceNumber { get; }
    }
}