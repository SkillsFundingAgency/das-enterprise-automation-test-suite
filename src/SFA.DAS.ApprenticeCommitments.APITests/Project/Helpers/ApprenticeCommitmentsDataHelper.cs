using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsDataHelper
    {
        public ApprenticeCommitmentsDataHelper(RandomDataGenerator randomDataGenerator, bool isPerfTest)
        {
            var emailprefix = isPerfTest ? "Apprentice_PerfTest_" : "ApprenticeAccount_";
            var emaildomain = isPerfTest ? "email.com" : "mailinator.com";
            Email = $"{emailprefix}{DateTime.Now:ddMMMyy_HHmmss_fffff}@{emaildomain}";
            NewEmail = $"New{Email}";
            ApprenticeFirstname = $"F_{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            ApprenticeLastname = $"L_{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
        }

        public string Email { get; }

        public string NewEmail { get; }

        public string ApprenticeFirstname { get; }

        public string ApprenticeLastname { get; }
    }
}