using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1ManagedataHelper
    {
        public RAAV1ManagedataHelper() => TitleComments = RandomDataGenerator.GenerateRandomAlphabeticString(10);

        public string TitleComments { get; }
    }
}

