using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : RegistrationBasePage(context)
    {
        protected override string PageTitle => "Enter your training provider’s name or reference number (UKPRN)";

        protected override By PageHeader => By.Id("jsChgTitle");
        private static By UKProviderReferenceNumberText => By.Id("Ukprn");
        private static By FirstOption => By.CssSelector("#Ukprn__option--0");
        protected override By ContinueButton => By.Id("Ukprn-button");

        public ConfirmTrainingProviderPage SearchForATrainingProvider(string ukprn)
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(UKProviderReferenceNumberText, ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            return new ConfirmTrainingProviderPage(context);
        }
    }
}
