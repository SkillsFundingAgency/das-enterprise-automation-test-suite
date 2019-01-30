using OpenQA.Selenium;
using System;
using System.Linq;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class RandomDataGenerator
    {
        protected IWebDriver webDriver;
        const String alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const String numbers = "0123456789";
        const String specialChars = "!@£$%^&*()_+{}:<>?-=[];',./";

        public RandomDataGenerator(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }


        public String GenerateRandomAlphabeticString(int length)
        {
            return GenerateRandomString(alphabets, length);
        }

        public String GenerateRandomNumber(int length)
        {
            return GenerateRandomString(numbers, length);
        }

        public String GenerateRandomAlphanumericString(int length)
        {
            return GenerateRandomString(alphabets + numbers, length);
        }

        public String GenerateRandomAlphanumericStringWithSpecialCharacters(int length)
        {
            return GenerateRandomString(alphabets + numbers + specialChars, length);
        }

        public String GenerateRandomEmail()
        {
            String emailDomain = "@example.com";
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
            Random rand = new Random();
            return rand.Next(min, max);
        }

        private String GenerateRandomString(String characters, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}