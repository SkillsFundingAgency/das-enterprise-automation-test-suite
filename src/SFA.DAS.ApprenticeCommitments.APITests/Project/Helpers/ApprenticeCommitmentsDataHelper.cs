using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsDataHelper
    {
        public ApprenticeCommitmentsDataHelper(RandomDataGenerator randomDataGenerator)
        {
            Email = $"ApprenticeAccount{DateTime.Now:ddMMMyy_HHmmss_fffff}@test.com";
            NewEmail = $"New{Email}";
            ApprenticeFirstname = $"F_{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            ApprenticeLastname = $"L_{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            DateOfBirthDay = randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = randomDataGenerator.GenerateRandomDobYear();
            NationalInsuranceNumber = $"AB3{randomDataGenerator.GenerateRandomWholeNumber(4)}5C";
        }

        public string Email { get; }

        public string NewEmail { get; }

        public string ApprenticeFirstname { get; }

        public string ApprenticeLastname { get; }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string NationalInsuranceNumber { get; }
    }
}