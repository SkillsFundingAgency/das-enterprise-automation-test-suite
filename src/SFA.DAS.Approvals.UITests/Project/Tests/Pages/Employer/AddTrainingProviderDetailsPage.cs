using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChooseYourMainTrainingProviderPage(ScenarioContext context) : ApprovalsBasePage(context, false)
    {
        // Page heading now includes the provider name dynamically; verify via presence of the UKPRN input instead.
        protected override string PageTitle => string.Empty;
        protected override By PageHeader => By.Id("Ukprn");

        protected override bool TakeFullScreenShot => false;
        private static By UKProviderReferenceNumberText => By.Id("Ukprn");

        private static By FirstOption => By.CssSelector("#Ukprn__option--0");

        protected override By ContinueButton => By.Id("Ukprn-button");

        private static By UkprnField => By.CssSelector(".govuk-input");

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            Continue();
            return new ConfirmTrainingProviderPage(context);
        }

        public ConfirmTrainingProviderPage EnterUkprnForPortableFlexiJobPilotProvider()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(UKProviderReferenceNumberText, portableFlexiJobProviderConfig.Ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            return new ConfirmTrainingProviderPage(context);
        }

        private ChooseYourMainTrainingProviderPage EnterUkprn()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(UKProviderReferenceNumberText, providerConfig.Ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            return this;
        }
    }
}
