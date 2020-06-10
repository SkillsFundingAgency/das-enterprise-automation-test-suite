using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class EditedApprenticeDataHelper : RandomElementHelper
    {
        public EditedApprenticeDataHelper(RandomDataGenerator randomDataGenerator, ApprenticeDataHelper apprenticeDataHelper) : base(randomDataGenerator)
        {
            ApprenticeEditedFirstname = apprenticeDataHelper.ApprenticeFirstname;
            ApprenticeEditedLastname = apprenticeDataHelper.ApprenticeLastname;
            DateOfBirthDay = randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = randomDataGenerator.GenerateRandomDobYear();
            EmployerReference = randomDataGenerator.GenerateRandomAlphanumericString(10);
            ProviderRefernce = randomDataGenerator.GenerateRandomAlphanumericString(10);
            TrainingPrice = "2" + randomDataGenerator.GenerateRandomNumber(3);
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
            ApprenticeEditedFirstname = randomDataGenerator.GenerateRandomAlphabeticString(8);
            return ApprenticeEditedFirstname;
        }

        public string SetCurrentApprenticeEditedLastname()
        {
            ApprenticeEditedLastname = randomDataGenerator.GenerateRandomAlphabeticString(12);
            return ApprenticeEditedLastname;
        }

        public string ApprenticeEditedFirstname { get; private set; }

        public string ApprenticeEditedLastname { get; private set; }

    }
}
