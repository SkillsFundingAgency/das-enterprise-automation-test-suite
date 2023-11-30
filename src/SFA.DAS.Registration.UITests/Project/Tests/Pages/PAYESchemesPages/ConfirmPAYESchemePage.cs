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

        private readonly string _paye;

        public ConfirmPAYESchemePage(ScenarioContext context, string paye) : base(context) { VerifyPage(); _paye = paye; }

        public PAYESchemeAddedPage ClickContinueInConfirmPAYESchemePage()
        {
            Continue();
            return new PAYESchemeAddedPage(context, _paye);
        }
    }
}
