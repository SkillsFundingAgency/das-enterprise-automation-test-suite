using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RandomElementHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> elements, bool randomElement = true, int nthElement = 0)
        {
            if (randomElement)
            {
                var randomNumber = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, elements.Count - 1);
                return elements[randomNumber];
            }
            else
                return elements[nthElement];
        }
    }
}
