using System;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class EditedApprenticeDataHelper : RandomCourseHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;

        public EditedApprenticeDataHelper(RandomDataGenerator randomDataGenerator, ApprenticeDataHelper approvalsDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)
        {
            _apprenticeCourseDataHelper = apprenticeCourseDataHelper;
            _randomDataGenerator = randomDataGenerator;
            ApprenticeEditedFirstname = approvalsDataHelper.ApprenticeFirstname;
            ApprenticeEditedLastname = approvalsDataHelper.ApprenticeLastname;
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            ProviderRefernce = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            TrainingPrice = "2" + _randomDataGenerator.GenerateRandomNumber(3);
            EditedCourse = RandomCourse();
        }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string EmployerReference { get; }

        public string ProviderRefernce { get; }

        public string TrainingPrice { get; }

        public string ApprenticeEditedFullName => $"{ApprenticeEditedFirstname} {ApprenticeEditedLastname}";

        public string SetCurrentApprenticeEditedFirstname()
        {
            ApprenticeEditedFirstname = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            return ApprenticeEditedFirstname;
        }

        public string SetCurrentApprenticeEditedLastname()
        {
            ApprenticeEditedLastname = _randomDataGenerator.GenerateRandomAlphabeticString(12);
            return ApprenticeEditedLastname;
        }

        public string SetCurrentApprenticeEditedCourse()
        {
            if ((_apprenticeCourseDataHelper.Course.Equals(EditedCourse)))
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
