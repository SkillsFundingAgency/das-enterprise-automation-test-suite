using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class CampaingnsBasePage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly CampaignsConfig campaignsConfig;
        protected readonly CampaignsDataHelper campaignsDataHelper;
        #endregion

        private By Links => By.CssSelector("a");

        public CampaingnsBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            campaignsConfig = context.GetCampaignsConfig<CampaignsConfig>();
            campaignsDataHelper = context.Get<CampaignsDataHelper>();
        }

        public void VerifyLinks()
        {
            var internalLinks = pageInteractionHelper.FindElements(Links);

            foreach (var item in internalLinks)
            {
                var href = item.GetAttribute("href");
                objectContext.Replace(item.Text, href);
                
                if (string.IsNullOrEmpty(href))
                    throw new System.Exception($"{item.Text} link is broken");
            }
        }

    }
}
