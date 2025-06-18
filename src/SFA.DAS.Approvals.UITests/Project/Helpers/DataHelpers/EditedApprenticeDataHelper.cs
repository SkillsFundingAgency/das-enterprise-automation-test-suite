using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class EditedApprenticeDataHelper(ApprenticeDataHelper apprenticeDataHelper)
    {
        public int DateOfBirthDay { get; } = RandomDataGenerator.GenerateRandomDateOfMonth();

        public int DateOfBirthMonth { get; } = RandomDataGenerator.GenerateRandomMonth();

        public int DateOfBirthYear { get; } = RandomDataGenerator.GenerateRandomDobYear();

        public string EmployerReference { get; } = RandomDataGenerator.GenerateRandomAlphanumericString(10);

        public string ProviderRefernce { get; } = RandomDataGenerator.GenerateRandomAlphanumericString(10);

        public string TrainingCost { get; } = "2" + RandomDataGenerator.GenerateRandomNumber(3);

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

        public string ApprenticeEditedFirstname { get; private set; } = apprenticeDataHelper.ApprenticeFirstname;

        public string ApprenticeEditedLastname { get; private set; } = apprenticeDataHelper.ApprenticeLastname;

        public void UpdateCurrentApprenticeName(string firstName, string lastName)
        {
            ApprenticeEditedFirstname = firstName;
            ApprenticeEditedLastname = lastName;
        }
    }
}
