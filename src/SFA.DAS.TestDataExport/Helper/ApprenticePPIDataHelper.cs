using System;
using System.Linq;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.Helper
{
    public class ApprenticePPIDataHelper
    {
        private readonly bool _isApprenticeCommitments;
        private readonly string _apprenticeEmail;

        public ApprenticePPIDataHelper(RandomDataGenerator randomDataGenerator, string[] _tags)
        {
            bool isPerfTest = _tags.Contains("perftest");
            _isApprenticeCommitments = _tags.Contains("apprenticecommitments");

            var emailprefix = isPerfTest ? "Apprentice_PerfTest_" : "ApprenticeAccount_";
            var emaildomain = isPerfTest ? "email.com" : "mailinator.com";

            var firstName = randomDataGenerator.GenerateRandomAlphabeticString(10);
            var lastName = randomDataGenerator.GenerateRandomAlphabeticString(10);

            ApprenticeFirstname = _isApprenticeCommitments ? $"CMAD_F_{firstName}" : $"F_{firstName}";
            ApprenticeLastname = _isApprenticeCommitments ? $"CMAD_L_{lastName}" : $"L_{lastName}";

            DateOfBirthDay = randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = randomDataGenerator.GenerateRandomDobYear();
            
            _apprenticeEmail = $"{emailprefix}{DateTime.Now:ddMMMyy_HHmmss_fffff}@{emaildomain}";
        }

        public string ApprenticeEmail => _isApprenticeCommitments ? _apprenticeEmail : $"{ApprenticeFirstname}_{ApprenticeLastname}_{DateTime.Now.ToSeconds()}_{DateTime.Now.ToNanoSeconds()}@email.com";

        public string ApprenticeFirstname { get; set; }

        public string ApprenticeLastname { get; set; }

        public int DateOfBirthDay { get; set; }

        public int DateOfBirthMonth { get; set; }

        public int DateOfBirthYear { get; set; }
    }
}
