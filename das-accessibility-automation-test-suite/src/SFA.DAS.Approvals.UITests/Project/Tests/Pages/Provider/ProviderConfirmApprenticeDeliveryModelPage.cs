using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeliveryModelPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Select the apprenticeship delivery model";

        private static By ContinueBtn => By.XPath("//*[@id='selectDeliveryModel']/button");

        public ProviderEditApprenticeDetailsPage ConfirmDeliveryModelChangeToRegular()
        {
            formCompletionHelper.ClickElement(ContinueBtn);
            return new ProviderEditApprenticeDetailsPage(context);
        }
    }
}