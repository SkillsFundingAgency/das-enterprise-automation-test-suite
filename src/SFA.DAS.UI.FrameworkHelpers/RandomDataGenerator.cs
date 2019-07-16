using System;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RandomDataGenerator
    {
        private const string Alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const string SpecialChars = "!@£$%^&*()_+{}:<>?-=[];',./";

        public static string GenerateRandomAlphabeticString(int length)
        {
            return GenerateRandomString(Alphabets, length);
        }

        public static string GenerateRandomNumber(int length)
        {
            return GenerateRandomString(Numbers, length);
        }

        public static string GenerateRandomAlphanumericString(int length)
        {
            return GenerateRandomString(Alphabets + Numbers, length);
        }

        public static string GenerateRandomAlphanumericStringWithSpecialCharacters(int length)
        {
            return GenerateRandomString(Alphabets + Numbers + SpecialChars, length);
        }

        public static string GenerateRandomEmail()
        {
            var emailDomain = "@example.com";
            return GenerateRandomAlphanumericString(10) + DateTime.Now.Millisecond + emailDomain;
        }

        public static int GenerateRandomDateOfMonth()
        {
            return GenerateRandomNumberBetweenTwoValues(1, 28);
        }

        public static int GenerateRandomMonth()
        {
            return GenerateRandomNumberBetweenTwoValues(1, 13);
        }

        public static int GenerateRandomNumberBetweenTwoValues(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }

        private static string GenerateRandomString(string characters, int length)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select<string, char>(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}