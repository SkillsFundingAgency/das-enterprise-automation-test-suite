using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public abstract class RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RandomElementHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> elements) => _randomDataGenerator.GetRandomElementFromListOfElements(elements);
    }
}