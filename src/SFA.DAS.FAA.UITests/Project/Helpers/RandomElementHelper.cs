using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.FAA.UITests.Project.Helpers
{
    public abstract class RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RandomElementHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> elements)
        {
            var randomNumber = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, elements.Count - 1);

            return elements[randomNumber];
        }
    }
}