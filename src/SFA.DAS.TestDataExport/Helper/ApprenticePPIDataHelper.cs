using System;
using System.Linq;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.Helper
{
    public class ApprenticePPIDataHelper
    {
        private readonly bool _isApprenticeCommitments;
        private readonly string[] _tags;

        private readonly string emailprefix, emaildomain;

        public ApprenticePPIDataHelper(string[] tags)
        {
            _tags = tags;

            bool isPerfTest = tags.Contains("perftest");

            _isApprenticeCommitments = tags.Contains("apprenticecommitments");

            emailprefix = isPerfTest ? "Apprentice_PerfTest_" : "ApprenticeAccount_";
            emaildomain = isPerfTest ? "email.com" : "mailinator.com";

            var nameprefix = _isApprenticeCommitments && _tags.Contains("aslistedemployer") ? $"CMAD_LE_" : _isApprenticeCommitments ? $"CMAD_" : string.Empty;

            var dateOfBirth = new DateTime(RandomDataGenerator.GenerateRandomDobYear(), RandomDataGenerator.GenerateRandomMonth(), RandomDataGenerator.GenerateRandomDateOfMonth());

            CreatePPIData(nameprefix, dateOfBirth);
        }

        public ApprenticePPIDataHelper(DateTime dateOfBirth)
        {
            emailprefix = "ApprenticeAccount_";
            emaildomain = "mailinator.com";

            var nameprefix = "FLP_LE_";

            CreatePPIData(nameprefix, dateOfBirth);
        }

        private static string GetApprenticeEmail(string emailprefix, string emaildomain) => $"{emailprefix}{DateTime.Now:ddMMMyy_HHmmss_fffff}@{emaildomain}";

        private void CreatePPIData(string nameprefix, DateTime dateOfBirth)
        {
            var firstName = RandomDataGenerator.GenerateRandomAlphabeticString(10);
            var lastName = RandomDataGenerator.GenerateRandomAlphabeticString(10);

            ApprenticeFirstname = $"{nameprefix}F_{firstName}";
            ApprenticeLastname = $"{nameprefix}L_{lastName}";

            DateOfBirthDay = dateOfBirth.Day;
            DateOfBirthMonth = dateOfBirth.Month;
            DateOfBirthYear = dateOfBirth.Year;
        }

        public string ApprenticeEmail => _isApprenticeCommitments ? GetApprenticeEmail(emailprefix, emaildomain) : $"{ApprenticeFirstname}_{ApprenticeLastname}_{DateTime.Now.ToSeconds()}_{DateTime.Now.ToNanoSeconds()}@email.com";

        public string ApprenticeFirstname { get; set; }

        public string ApprenticeLastname { get; set; }

        public int DateOfBirthDay { get; set; }

        public int DateOfBirthMonth { get; set; }

        public int DateOfBirthYear { get; set; }
    }
}
