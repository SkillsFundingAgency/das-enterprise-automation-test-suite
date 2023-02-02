using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeliveryModelPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Select the apprenticeship delivery model";

        private By ContinueBtn => By.XPath("//*[@id='selectDeliveryModel']/button");

        public ProviderConfirmApprenticeDeliveryModelPage(ScenarioContext context) : base(context) { }

        public ProviderEditApprenticeDetailsPage ConfirmDeliveryModelChangeToRegular()
        {
            formCompletionHelper.ClickElement(ContinueBtn);
            return new ProviderEditApprenticeDetailsPage(context);
        }
    }
}