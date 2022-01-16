using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmRequestForChangeOfProviderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Are you sure you want to send this request to";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("continue-button");

        public ConfirmRequestForChangeOfProviderPage(ScenarioContext context) : base(context)  { }

        public ChangeOfTrainingProviderRequestedPage SelectYesAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new ChangeOfTrainingProviderRequestedPage(context);
        }
    }
}
