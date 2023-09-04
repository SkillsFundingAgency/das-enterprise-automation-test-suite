using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsVerifyLinks : CampaingnsBasePage
    {
        private static By Links => By.CssSelector("a");

        private static By VideoLinks => By.CssSelector("a[data-module='videoPlayer']");

        protected override string PageTitle => "";

        public CampaingnsVerifyLinks(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public void VerifyLinks() => VerifyLinks(Links, "href", (x) => x.Text);

        public void VerifyVideoLinks() => VerifyLinks(VideoLinks, "data-videourl", (x) => x?.GetAttribute("id"));

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
