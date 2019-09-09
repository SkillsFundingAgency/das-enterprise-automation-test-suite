using System;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class EditedApprenticeDataHelper : RandomCourseHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly ApprenticeDataHelper _approvalsDataHelper;

        public EditedApprenticeDataHelper(RandomDataGenerator randomDataGenerator, ApprenticeDataHelper approvalsDataHelper)
        {
            _approvalsDataHelper = approvalsDataHelper;
            _randomDataGenerator = randomDataGenerator;
            ApprenticeEditedFirstname = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            ApprenticeEditedLastname = _randomDataGenerator.GenerateRandomAlphabeticString(12);
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            ProviederRefernce = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            TrainingPrice = "2" + _randomDataGenerator.GenerateRandomNumber(3);
            EditedCourse = RandomCourse();
        }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string EmployerReference { get; }

        public string ProviederRefernce { get; }

        public string TrainingPrice { get; }

        public string ApprenticeEditedFullName => $"{ApprenticeEditedFirstname} {ApprenticeEditedLastname}";

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
            if ((_approvalsDataHelper.ApprenticeLastname.Equals(ApprenticeEditedLastname)))
            {
                ApprenticeEditedLastname = _randomDataGenerator.GenerateRandomAlphabeticString(12);
            }
            return ApprenticeEditedLastname;
        }

        public string SetCurrentApprenticeEditedCourse()
        {
            if ((_approvalsDataHelper.Course.Equals(EditedCourse)))
            {
                EditedCourse = RandomCourse();
            }
            return EditedCourse;
        }

        private string ApprenticeEditedFirstname { get; set; }

        private string ApprenticeEditedLastname { get; set; }

        private string EditedCourse { get; set; }
    }
}
