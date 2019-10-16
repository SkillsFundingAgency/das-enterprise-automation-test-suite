using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class EditedApprenticeDataHelper 
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public EditedApprenticeDataHelper(RandomDataGenerator randomDataGenerator, ApprenticeDataHelper apprenticeDataHelper)
        {
            _randomDataGenerator = randomDataGenerator;
            ApprenticeEditedFirstname = $"F_{_randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            ApprenticeEditedLastname = $"L_{_randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            ProviderRefernce = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            TrainingPrice = "2" + _randomDataGenerator.GenerateRandomNumber(3);
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

        public string ApprenticeEditedFirstname { get; set; }

        public string ApprenticeEditedLastname { get; set; }

    }
}
