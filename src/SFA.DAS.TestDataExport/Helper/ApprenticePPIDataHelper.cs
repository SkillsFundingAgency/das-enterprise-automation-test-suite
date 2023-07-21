using System;
using System.Linq;
using SFA.DAS.FrameworkHelpers;

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

            var nameprefix = _isApprenticeCommitments && _tags.Contains("aslistedemployer") ? $"CMAD_LE_" : _isApprenticeCommitments ? $"CMAD_" : string.Empty;

            var dateOfBirth = new DateTime(RandomDataGenerator.GenerateRandomDobYear(), RandomDataGenerator.GenerateRandomMonth(), RandomDataGenerator.GenerateRandomDateOfMonth());

            CreatePPIData(nameprefix, dateOfBirth);

            _apprenticeEmail = GetApprenticeEmail(emailprefix, emaildomain);
        }

        public ApprenticePPIDataHelper(DateTime dateOfBirth)
        {
            var emailprefix = "ApprenticeAccount_";
            var emaildomain = "mailinator.com";

            var nameprefix = "FLP_LE_";

            CreatePPIData(nameprefix, dateOfBirth);

            _apprenticeEmail = GetApprenticeEmail(emailprefix, emaildomain);
        }

        private static string GetApprenticeEmail(string emailprefix, string emaildomain) => $"{emailprefix}{DateTime.Now:ddMMMyy_HHmmss_fffff}@{emaildomain}";

        private void CreatePPIData(string nameprefix, DateTime dateOfBirth)
        {
            var randomPersonNameHelper = new RandomPersonNameHelper();

            var firstName = randomPersonNameHelper.FirstName;
            var lastName = randomPersonNameHelper.LastName;

            ApprenticeFirstname = $"{nameprefix}F_{firstName}";
            ApprenticeLastname = $"{nameprefix}L_{lastName}";

            DateOfBirthDay = dateOfBirth.Day;
            DateOfBirthMonth = dateOfBirth.Month;
            DateOfBirthYear = dateOfBirth.Year;
        }

        public string ApprenticeEmail => _isApprenticeCommitments ? _apprenticeEmail : $"{ApprenticeFirstname}_{ApprenticeLastname}_{DateTime.Now.ToSeconds()}_{DateTime.Now.ToNanoSeconds()}@email.com";

        public string ApprenticeFirstname { get; set; }

        public string ApprenticeLastname { get; set; }

        public string ApprenticeFullName => $"{ApprenticeFirstname} {ApprenticeLastname}";

        public int DateOfBirthDay { get; set; }

        public int DateOfBirthMonth { get; set; }

        public int DateOfBirthYear { get; set; }

        public DateTime ApprenticeDob => new(DateOfBirthYear, DateOfBirthMonth, DateOfBirthDay);
    }
}
