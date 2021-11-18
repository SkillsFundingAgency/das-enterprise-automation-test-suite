using System;
using System.Linq;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.Helper
{
    public class ApprenticePPIDataHelper
    {
        private readonly bool _isApprenticeCommitments;
        private readonly string _apprenticeEmail;
        private readonly string[] _tags;

        public ApprenticePPIDataHelper(string[] tags)
        {
            _tags = tags;

            bool isPerfTest = tags.Contains("perftest");

            _isApprenticeCommitments = tags.Contains("apprenticecommitments");

            var emailprefix = isPerfTest ? "Apprentice_PerfTest_" : "ApprenticeAccount_";
            var emaildomain = isPerfTest ? "email.com" : "mailinator.com";

            var firstName = RandomDataGenerator.GenerateRandomAlphabeticString(10);
            var lastName = RandomDataGenerator.GenerateRandomAlphabeticString(10);

            var nameprefix = _isApprenticeCommitments && _tags.Contains("aslistedemployer") ? $"CMAD_LE_" : _isApprenticeCommitments ? $"CMAD_" : string.Empty;

            ApprenticeFirstname = $"{nameprefix}F_{firstName}";
            ApprenticeLastname = $"{nameprefix}L_{lastName}";

            DateOfBirthDay = RandomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = RandomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = RandomDataGenerator.GenerateRandomDobYear();
            
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
