using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public TMDataHelper(RandomDataGenerator randomDataGenerator): base(randomDataGenerator) => _randomDataGenerator = randomDataGenerator;

        public int GenerateRandomNumberBetweenTwoValues(int options) => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, options);

        public int PledgeAmount(int availablePledgeAmount) => GenerateRandomNumberBetweenTwoValues(availablePledgeAmount);

        public string GetRandomLocation() => GetRandomElementFromListOfElements(Locations);

        private List<string> Locations => new List<string>()
        {
            "Coventry, West Midlands",
            "Greater London, Berkshire",
            "Grays, Essex",
            "Manchester, Greater Manchester",
            "Sheffield, South Yorkshire",
            "Hatfield, Hertfordshire",
            "Sutton, Greater London",
            "Cheam, Greater London",
            "Worcester, Worcestershire"
        };
    }
}
