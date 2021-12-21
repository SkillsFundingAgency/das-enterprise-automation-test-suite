using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingProviderDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add training provider details";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("continue-button");

        private By UkprnField => By.CssSelector(".govuk-input");

        public AddTrainingProviderDetailsPage(ScenarioContext context) : base(context) { }

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            Continue();
            return new ConfirmTrainingProviderPage(context);
        }

        private AddTrainingProviderDetailsPage EnterUkprn()
        {
            formCompletionHelper.EnterText(UkprnField, providerConfig.Ukprn);
            return this;
        }
    }
}
