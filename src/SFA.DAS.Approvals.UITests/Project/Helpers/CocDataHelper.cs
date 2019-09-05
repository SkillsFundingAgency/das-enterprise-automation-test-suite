using System;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class CocDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly ApprovalsDataHelper _approvalsDataHelper;

        public CocDataHelper(RandomDataGenerator randomDataGenerator, ApprovalsDataHelper approvalsDataHelper)
        {
            _approvalsDataHelper = approvalsDataHelper;
            _randomDataGenerator = randomDataGenerator;
            ApprenticeEditedFirstname = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            ApprenticeEditedLastname = _randomDataGenerator.GenerateRandomAlphabeticString(12);
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
        }

        public string ApprenticeEditedFirstname { get ; private set; }

        public string ApprenticeEditedLastname { get; private set; }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string EmployerReference { get; }

        public string SetCurrentApprenticeEditedFirstname()
        {
            if ((_approvalsDataHelper.ApprenticeFirstname.Equals(ApprenticeEditedFirstname)))
            {
                ApprenticeEditedFirstname = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            }
            return ApprenticeEditedFirstname;
        }

        public String SetCurrentApprenticeEditedLastname()
        {
            if ((_approvalsDataHelper.ApprenticeFirstname.Equals(ApprenticeEditedFirstname)))
            {
                ApprenticeEditedLastname = _randomDataGenerator.GenerateRandomAlphabeticString(12);
            }
            return ApprenticeEditedLastname;
        }
    }
}
