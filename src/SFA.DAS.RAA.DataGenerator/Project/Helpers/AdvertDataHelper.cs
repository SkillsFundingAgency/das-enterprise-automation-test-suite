using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class AdvertDataHelper
    {
        public AdvertDataHelper()
        {
            AdditionalQuestion1 = RandomQuestionString(20);
            AdditionalQuestion2 = RandomQuestionString(20);
        }

        public string AdditionalQuestion1 { get; }

        public string AdditionalQuestion2 { get; }

        public static string RandomQuestionString(int length) => $"{RandomDataGenerator.GenerateRandomAlphabeticString(length)}?";
    }
}