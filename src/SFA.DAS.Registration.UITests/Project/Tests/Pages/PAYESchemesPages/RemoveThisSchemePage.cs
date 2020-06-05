using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class RemoveThisSchemePage : RegistrationBasePage
    {
        protected override string PageTitle => "Remove this scheme?";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By PageHeader => By.CssSelector(".govuk-caption-l");
        protected override By ContinueButton => By.XPath("//button[text()='Continue']");
        private By YesRemoveSchemeRadioButton => By.Id("yes");
        #endregion

        public RemoveThisSchemePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PAYESchemesPage SelectYesRadioButtonAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(YesRemoveSchemeRadioButton));
            Continue();
            return new PAYESchemesPage(_context);
        }
    }
}
