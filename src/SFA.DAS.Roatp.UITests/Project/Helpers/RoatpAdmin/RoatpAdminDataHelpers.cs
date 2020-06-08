using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminDataHelpers : RandomDataGeneratorHelper
    {
        public RoatpAdminDataHelpers(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) { }

        public DateTime Dob => DateTime.Now.AddYears(-45);

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => GetRandomElementFromListOfElements(options);
    }
}
