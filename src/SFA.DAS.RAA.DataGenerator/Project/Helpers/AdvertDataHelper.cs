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

        public string AdditionalQuestion1 { get; private set; }

        public string AdditionalQuestion2 { get; private set; }

        public void SetAdditionalQuestion1(string question) => AdditionalQuestion1 = question;

        public void SetAdditionalQuestion2(string question) => AdditionalQuestion2 = question;

        public static string RandomQuestionString(int length) => $"{RandomDataGenerator.GenerateRandomAlphabeticString(length)}?";
    }
}

