using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public TMDataHelper(RandomDataGenerator randomDataGenerator): base(randomDataGenerator) => _randomDataGenerator = randomDataGenerator;

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => base.GetRandomElementFromListOfElements(options);

        public int PledgeAmount(int availablePledgeAmount) => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, availablePledgeAmount);

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
