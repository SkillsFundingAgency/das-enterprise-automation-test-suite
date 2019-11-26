using System;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RandomDataGenerator
    {
        private const string Alphabets = LowerCaseAlphabets + UpperCaseAlphabets;
        private const string LowerCaseAlphabets = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCaseAlphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

        public string GenerateRandomPassword(int noOfUppercaseLetters, int noOfLowerCaseLetters, int noOfNumbers, int noOfSpecialChars)
        {
            var randomString = GenerateRandomString(LowerCaseAlphabets, noOfUppercaseLetters);
            randomString += GenerateRandomString(UpperCaseAlphabets, noOfLowerCaseLetters);
            randomString += GenerateRandomString(Numbers, noOfNumbers);
            randomString += GenerateRandomString(SpecialChars, noOfSpecialChars);
            return randomString;
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

        public int GenerateRandomDobYear()
        {
            int yearsToAdd = GenerateRandomNumberBetweenTwoValues(-30, -18);
            DateTime date = DateTime.Now.AddYears(yearsToAdd);
            return date.Year;
        }

        public String GenerateRandomUln()
        {
            String randomUln = GenerateRandomNumberBetweenTwoValues(10, 99).ToString()
                + DateTime.Now.ToString("ssffffff");

            for (int i = 1; i < 30; i++)
            {
                if (IsValidCheckSum(randomUln))
                {
                    return randomUln;
                }
                randomUln = (long.Parse(randomUln) + 1).ToString();
            }
            throw new Exception("Unable to generate ULN");
        }

        private bool IsValidCheckSum(string uln)
        {
            var ulnCheckArray = uln.ToCharArray()
                                    .Select(c => long.Parse(c.ToString()))
                                    .ToList();

            var multiplier = 10;
            long checkSumValue = 0;
            for (var i = 0; i < 10; i++)
            {
                checkSumValue += ulnCheckArray[i] * multiplier;
                multiplier--;
            }

            return checkSumValue % 11 == 10;
        }

        private string GenerateRandomString(string characters, int length)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}