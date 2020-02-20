using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminDataHelpers
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RoatpAdminDataHelpers(RandomDataGenerator randomDataGenerator) => _randomDataGenerator = randomDataGenerator;

        public DateTime Dob => DateTime.Now.AddYears(-45);

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => _randomDataGenerator.GetRandomElementFromListOfElements(options);
    }
}
