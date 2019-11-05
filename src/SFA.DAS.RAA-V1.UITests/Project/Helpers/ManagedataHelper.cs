using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class ManagedataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public ManagedataHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            TitleComments = _randomDataGenerator.GenerateRandomAlphabeticString(10);
        }

        public string TitleComments { get; }
    }
}

