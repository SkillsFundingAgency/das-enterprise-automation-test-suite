using System.Collections.Generic;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class RandomDataGeneratorHelper
    {
        protected readonly RandomDataGenerator randomDataGenerator;

        public RandomDataGeneratorHelper(RandomDataGenerator randomDataGenerator) => this.randomDataGenerator = randomDataGenerator;

        public T GetRandomElementFromListOfElements<T>(List<T> elements)
        {
            var randomNumber = randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, elements.Count - 1);

            return elements[randomNumber];
        }
    }
}