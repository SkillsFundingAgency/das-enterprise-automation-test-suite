using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class EditedApprenticeDataHelper
    {
        public EditedApprenticeDataHelper(ApprenticeDataHelper apprenticeDataHelper)
        {
            ApprenticeEditedFirstname = apprenticeDataHelper.ApprenticeFirstname;
            ApprenticeEditedLastname = apprenticeDataHelper.ApprenticeLastname;
            DateOfBirthDay = RandomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = RandomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = RandomDataGenerator.GenerateRandomDobYear();
            EmployerReference = RandomDataGenerator.GenerateRandomAlphanumericString(10);
            ProviderRefernce = RandomDataGenerator.GenerateRandomAlphanumericString(10);
            TrainingPrice = "2" + RandomDataGenerator.GenerateRandomNumber(3);
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
            ApprenticeEditedFirstname = RandomDataGenerator.GenerateRandomAlphabeticString(8);
            return ApprenticeEditedFirstname;
        }

        public string SetCurrentApprenticeEditedLastname()
        {
            ApprenticeEditedLastname = RandomDataGenerator.GenerateRandomAlphabeticString(12);
            return ApprenticeEditedLastname;
        }

        public string ApprenticeEditedFirstname { get; private set; }

        public string ApprenticeEditedLastname { get; private set; }

        public void UpdateCurrentApprenticeName(string firstName, string lastName)
        {
            ApprenticeEditedFirstname = firstName;
            ApprenticeEditedLastname = lastName;
        }
    }
}
