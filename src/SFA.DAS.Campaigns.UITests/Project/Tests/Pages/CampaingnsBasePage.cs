using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class CampaingnsBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly CampaignsConfig campaignsConfig;
        protected readonly CampaignsDataHelper campaignsDataHelper;
        #endregion

        private By Links => By.CssSelector("a");

        private By VideoLinks => By.CssSelector("a[data-module='videoPlayer']");

        public CampaingnsBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            campaignsConfig = context.GetCampaignsConfig<CampaignsConfig>();
            campaignsDataHelper = context.Get<CampaignsDataHelper>();
        }

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

                if (string.IsNullOrEmpty(attributeValue))
                    throw new System.Exception($"'{text}' element's '{attributeName}' attribute is broken - attributeValue : '{attributeValue}'");
            }
        }
    }
}
