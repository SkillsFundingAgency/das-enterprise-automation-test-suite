using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeshipDeliveryModelPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm the apprenticeship delivery model";

        private static By ContinueBtn => By.XPath("//*[@id='selectDeliveryModel']/button");

        public EditApprenticeDetailsPage ConfirmDeliveryModelChangeToRegular()
        {
            formCompletionHelper.ClickElement(ContinueBtn);
            return new EditApprenticeDetailsPage(context);
        }
    }
}
