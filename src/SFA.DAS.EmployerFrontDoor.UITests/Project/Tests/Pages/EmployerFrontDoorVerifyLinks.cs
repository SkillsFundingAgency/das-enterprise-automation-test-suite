using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class EmployerFrontDoorVerifyLinks : EmployerFrontDoorBasePage
    {
        private By Links => By.CssSelector("a");
        protected override string PageTitle => "";
        public EmployerFrontDoorVerifyLinks(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
        public void VerifyLinks() => VerifyLinks(Links, "href", (x) => x.Text);
        public void VerifyLinks(By locator, string attributeName, Func<IWebElement, string> func)
        {
            var internalLinks = pageInteractionHelper.FindElements(locator);

            foreach (var item in internalLinks)
            {
                var attributeValue = item.GetAttribute(attributeName);
                var text = func(item);
                objectContext.Replace(text, $"{attributeName}:{attributeValue}");

                if (string.IsNullOrEmpty(attributeValue) && !string.IsNullOrEmpty(text) && (item.GetAttribute("asp-action") == null))
                    throw new Exception($"'{text}' element's '{attributeName}' attribute is broken - attributeValue : '{attributeValue}'");

            }
        }
     
    }
}
