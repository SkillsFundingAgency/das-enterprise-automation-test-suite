using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderConfirmEmployerNonLevyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm employer";

        private By SaveAndContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderConfirmEmployerNonLevyPage(ScenarioContext context) : base(context) { }

        internal ProviderApprenticeshipTrainingPage ConfirmNonLevyEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(context);
        }

        internal SelectStandardPage ConfirmEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-true");
            formCompletionHelper.ClickElement(ContinueButton);
            return new SelectStandardPage(context);
        }

        internal SimplifiedPaymentsPilotPage ConfirmEmployerForFlexiTrainingProvider()
        {
            SelectRadioOptionByForAttribute("confirm-true");
            formCompletionHelper.ClickElement(ContinueButton);
            return new SimplifiedPaymentsPilotPage(context);
        }
    }
}
