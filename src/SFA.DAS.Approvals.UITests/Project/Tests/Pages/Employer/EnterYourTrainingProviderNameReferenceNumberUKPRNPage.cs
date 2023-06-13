using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Enter your training provider’s name or reference number (UKPRN)";
        
        protected override By PageHeader => By.Id("jsChgTitle");
        private By UKProviderReferenceNumberText => By.Id("Ukprn");
        private By FirstOption => By.CssSelector("#Ukprn__option--0");
        protected override By ContinueButton => By.Id("Ukprn-button");

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : base(context)  { }

        internal ConfirmTrainingProviderUnderPermissionsPage SearchForATrainingProvider(string ukprn)
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(UKProviderReferenceNumberText, ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            return new ConfirmTrainingProviderUnderPermissionsPage(context);
        }
    }
}
