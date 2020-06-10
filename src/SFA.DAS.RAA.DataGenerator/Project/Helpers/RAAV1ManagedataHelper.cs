using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1ManagedataHelper : RandomElementHelper
    {
        public RAAV1ManagedataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) => TitleComments = this.randomDataGenerator.GenerateRandomAlphabeticString(10);

        public string TitleComments { get; }
    }
}

