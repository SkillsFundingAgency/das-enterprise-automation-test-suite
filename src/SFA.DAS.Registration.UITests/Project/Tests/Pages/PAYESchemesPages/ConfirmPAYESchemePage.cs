using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class ConfirmPAYESchemePage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm PAYE scheme";
        
        #region Locators
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");
        protected override By ContinueButton => By.CssSelector("button#accept");
        #endregion

        public ConfirmPAYESchemePage(ScenarioContext context) : base(context) => VerifyPage();

        public PAYESchemeAddedPage ClickContinueInConfirmPAYESchemePage()
        {
            Continue();
            return new PAYESchemeAddedPage(context);
        }
    }
}
