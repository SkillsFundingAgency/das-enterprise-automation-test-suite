using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class ConsolidatedSupportBasePage(ScenarioContext context) : VerifyBasePage(context)
    {
        protected readonly ConsolidatedSupportConfig config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
        protected readonly ConsolidateSupportDataHelper dataHelper = context.Get<ConsolidateSupportDataHelper>();

        private static By CloseButton => By.CssSelector("[data-test-id='close-button']");

        private static By MainNavigationButton => By.CssSelector("#main_navigation button");

        protected void ClickHomeButton() => formCompletionHelper.ClickButtonByText(MainNavigationButton, "Home");

        protected void ClickOrganisationsButton() => formCompletionHelper.ClickButtonByText(MainNavigationButton, "Organisations");

        protected void NavigateTo(string url) => tabHelper.GoToUrl($"{UrlConfig.ConsolidatedSupport_WebBaseUrl}/users/{objectContext.GetUserId()}/{url}");

        protected void CloseAllTickets()
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                foreach (var element in pageInteractionHelper.FindElements(CloseButton).ToList()) element.Click();
            });
        }
    }
}
