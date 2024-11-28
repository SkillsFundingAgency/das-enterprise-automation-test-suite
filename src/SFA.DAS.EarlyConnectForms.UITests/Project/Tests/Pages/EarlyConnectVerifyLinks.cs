using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EarlyConnectVerifyLinks(ScenarioContext context, bool verifypage = true) : EarlyConnectBasePage(context, verifypage)
    {
        private static By Links => By.CssSelector("a");
        protected override string PageTitle => "";
        public void VerifyLinks() => VerifyLinks(Links, "href", (x) => x.Text);
     
        public void VerifyLinks(By locator, string attributeName, Func<IWebElement, string> func)
        {
            var internalLinks = pageInteractionHelper.FindElements(locator);

            foreach (var item in internalLinks)
            {
                var attributeValue = item.GetDomAttribute(attributeName);
                var text = func(item);
                objectContext.Replace(text, $"{attributeName}:{attributeValue}");

                if (string.IsNullOrEmpty(attributeValue) && !string.IsNullOrEmpty(text) && (item.GetDomAttribute("asp-action") == null))
                    throw new Exception($"'{text}' element's '{attributeName}' attribute is broken - attributeValue : '{attributeValue}'");

            }
        }
    }
}
