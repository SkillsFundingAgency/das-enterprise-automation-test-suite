using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsPage : CampaingnsBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By FiuCardHeading => By.CssSelector(".fiu-card__heading");
        
        private By Links => By.CssSelector("a");

        private By VideoLinks => By.CssSelector("a[data-module='videoPlayer']");

        protected override string PageTitle => "";

        public CampaingnsPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) => _context = context;

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
                
                if (string.IsNullOrEmpty(attributeValue) && !string.IsNullOrEmpty(text))
                    throw new Exception($"'{text}' element's '{attributeName}' attribute is broken - attributeValue : '{attributeValue}'");
            }
        }

        protected TResult NavigateTo<TResult>(By parentLocator, By childLocator, Func<ScenarioContext, TResult> func)
        {
            formCompletionHelper.ClickElement(() =>
            {
                pageInteractionHelper.FocusTheElement(parentLocator);
                return pageInteractionHelper.FindElement(childLocator);
            });

            return func(_context);
        }
    }
}
