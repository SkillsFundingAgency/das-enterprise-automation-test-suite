using SFA.DAS.TestDataExport.Helper;
using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsDataHelper
    {
        public ApprenticeCommitmentsDataHelper(ApprenticePPIDataHelper apprenticePPIDataHelper)
        {
            ApprenticeEmail = apprenticePPIDataHelper.ApprenticeEmail;
            NewEmail = $"New{ApprenticeEmail}";
            ApprenticeFirstname = apprenticePPIDataHelper.ApprenticeFirstname;
            ApprenticeLastname = apprenticePPIDataHelper.ApprenticeLastname;
            DateOfBirthDay = apprenticePPIDataHelper.DateOfBirthDay;
            DateOfBirthMonth = apprenticePPIDataHelper.DateOfBirthMonth;
            DateOfBirthYear = apprenticePPIDataHelper.DateOfBirthYear;
        }

        public string ApprenticeEmail { get; }

        public string NewEmail { get; }

        public string ApprenticeFirstname { get; }

        public string ApprenticeLastname { get; }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public DateTime ApprenticeDob => new DateTime(DateOfBirthDay, DateOfBirthMonth, DateOfBirthYear);
    }
}