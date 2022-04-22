using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class ConsolidatedSupportBasePage : VerifyBasePage
    {
        protected readonly ConsolidatedSupportConfig config;
        protected readonly ConsolidateSupportDataHelper dataHelper;

        private By CloseButton => By.CssSelector("[data-test-id='close-button']");

        public ConsolidatedSupportBasePage(ScenarioContext context) : base(context)
        {
            config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            dataHelper = context.Get<ConsolidateSupportDataHelper>();
        }

        protected void NavigateTo(string url) => tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_WebUrl, $"users/{objectContext.GetUserId()}/{url}");

        protected void CloseAllTickets()
        {
            pageInteractionHelper.InvokeAction(() => 
            {
                foreach (var element in pageInteractionHelper.FindElements(CloseButton).ToList()) element.Click();
            });
        }
    }
}
