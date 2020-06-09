using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1ManagedataHelper : RandomDataGeneratorHelper
    {
        public RAAV1ManagedataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) => TitleComments = randomDataGenerator.GenerateRandomAlphabeticString(10);

        public string TitleComments { get; }
    }
}

