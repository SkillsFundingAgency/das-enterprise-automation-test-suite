using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1ManagedataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RAAV1ManagedataHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            TitleComments = _randomDataGenerator.GenerateRandomAlphabeticString(10);
        }

        public string TitleComments { get; }
    }
}

