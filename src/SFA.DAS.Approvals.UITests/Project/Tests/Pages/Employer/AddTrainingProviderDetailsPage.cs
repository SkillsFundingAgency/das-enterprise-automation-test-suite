using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingProviderDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Add training provider details";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("continue-button");

        private static By UkprnField => By.CssSelector(".govuk-input");

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            Continue();
            return new ConfirmTrainingProviderPage(context);
        }

        public ConfirmTrainingProviderPage EnterUkprnForPortableFlexiJobPilotProvider()
        {
            formCompletionHelper.EnterText(UkprnField, portableFlexiJobProviderConfig.Ukprn);
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
