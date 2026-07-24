using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PausePymtToYourProviderPage(ScenarioContext context) : ChangeApprenticeStatus(context)
    {
        protected override string PageTitle => "Pause payments to your training provider";

        private By ConfirmChangesButton => By.Id("submit-change-payments");

        public new PaymentsPausedConfirmationPage SelectPausePaymentsAndConfirm()
        {
            formCompletionHelper.SelectFromDropDownByText(By.Id("FreezePaymentsReason"), "Learner is on a break");
            formCompletionHelper.SelectRadioOptionByText("Yes, pause payments");
            formCompletionHelper.ClickElement(ConfirmChangesButton);
            return new PaymentsPausedConfirmationPage(context);
        }
    }
}