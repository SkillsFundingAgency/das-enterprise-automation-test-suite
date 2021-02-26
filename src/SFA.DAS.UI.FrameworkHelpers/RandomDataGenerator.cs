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
        private const string WholeNumbers = "123456789";
        private const string SpecialChars = "!@£$%^&*()_+{}:<>?-=[];',./";

        public string GenerateRandomAlphabeticString(int length) => GenerateRandomString(Alphabets, length);

        public string GenerateRandomNumber(int length) => GenerateRandomString(Numbers, length);

        public string GenerateRandomWholeNumber(int length) => GenerateRandomString(WholeNumbers, length);

        public string GenerateRandomAlphanumericString(int length) => GenerateRandomString(Alphabets + Numbers, length);

        public string GenerateRandomAlphanumericStringWithSpecialCharacters(int length) => GenerateRandomString(Alphabets + Numbers + SpecialChars, length);

        public string GenerateRandomPassword(int noOfUppercaseLetters, int noOfLowerCaseLetters, int noOfNumbers, int noOfSpecialChars)
        {
            var randomString = GenerateRandomString(LowerCaseAlphabets, noOfUppercaseLetters);
            randomString += GenerateRandomString(UpperCaseAlphabets, noOfLowerCaseLetters);
            randomString += GenerateRandomString(Numbers, noOfNumbers);
            randomString += GenerateRandomString(SpecialChars, noOfSpecialChars);
            return randomString;
        }

        public string GenerateRandomEmail() => GenerateRandomAlphanumericString(10) + DateTime.Now.Millisecond + "@example.com";

        public int GenerateRandomDateOfMonth() => GenerateRandomNumberBetweenTwoValues(1, 28);

        public int GenerateRandomMonth() => GenerateRandomNumberBetweenTwoValues(1, 13);

        public int GenerateRandomNumberBetweenTwoValues(int min, int max) => new Random().Next(min, max);

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

        public string GenerateRandomFirstName()
        {
            var names = new string[] { "Oliver", "George", "Noah", "Arthur", "Harry", "Jack", "Charlie", "Henry",
            "Michael", "Ethan", "Thomas", "Freddie", "William", "James", "Edward", "Scarlett", "Daisy", "Phoebe",
            "Isabella", "Evelyn", "Lily", "Mia", "Emily", "Charlotte", "Rosie", "Amelia", "Olivia", "Eva", "Sophia", "Grace"};

            return names[new Random().Next(names.Length)];
        }

        public string GenerateRandomLastName()
        {
            var names = new string[] { "Cox", "Jones", "Taylor", "Williams", "Brown", "White", "Harris", "Martin",
            "Davies", "Wilson", "Cooper", "Evans", "King", "Baker", "Green", "Wright", "Clark", "Webb",
            "Robinson", "Hall", "Young", "Turner", "Hill", "Collins", "Allen", "Moore", "Knight", "Walker", "Wood", "Bennett"};

            return names[new Random().Next(names.Length)];
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