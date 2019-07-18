using System;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RandomDataGenerator
    {
        private const string Alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const string SpecialChars = "!@£$%^&*()_+{}:<>?-=[];',./";

        public string GenerateRandomAlphabeticString(int length)
        {
            return GenerateRandomString(Alphabets, length);
        }

        public string GenerateRandomNumber(int length)
        {
            return GenerateRandomString(Numbers, length);
        }

        public string GenerateRandomAlphanumericString(int length)
        {
            return GenerateRandomString(Alphabets + Numbers, length);
        }

        public string GenerateRandomAlphanumericStringWithSpecialCharacters(int length)
        {
            return GenerateRandomString(Alphabets + Numbers + SpecialChars, length);
        }

        public string GenerateRandomEmail()
        {
            var emailDomain = "@example.com";
            return GenerateRandomAlphanumericString(10) + DateTime.Now.Millisecond + emailDomain;
        }

        public int GenerateRandomDateOfMonth()
        {
            return GenerateRandomNumberBetweenTwoValues(1, 28);
        }

        public int GenerateRandomMonth()
        {
            return GenerateRandomNumberBetweenTwoValues(1, 13);
        }

        public int GenerateRandomNumberBetweenTwoValues(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }

        private string GenerateRandomString(string characters, int length)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}