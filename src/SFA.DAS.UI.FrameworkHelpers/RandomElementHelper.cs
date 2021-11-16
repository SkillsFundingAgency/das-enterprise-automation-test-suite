using System.Collections.Generic;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class RandomElementHelper
    {
        public RandomElementHelper() { }

        public T GetRandomElementFromListOfElements<T>(List<T> elements)
        {
            var randomNumber = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, elements.Count - 1);

            return elements[randomNumber];
        }
    }
}