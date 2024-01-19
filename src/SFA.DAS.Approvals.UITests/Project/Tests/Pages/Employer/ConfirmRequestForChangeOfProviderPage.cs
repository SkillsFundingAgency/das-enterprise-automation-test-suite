using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmRequestForChangeOfProviderPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Are you sure you want to send this request to";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("continue-button");

        public ChangeOfTrainingProviderRequestedPage SelectYesAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new ChangeOfTrainingProviderRequestedPage(context);
        }
    }
}
