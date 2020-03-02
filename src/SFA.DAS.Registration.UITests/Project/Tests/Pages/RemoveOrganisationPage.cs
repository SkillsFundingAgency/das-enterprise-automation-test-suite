using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class RemoveOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Remove organisation";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.CssSelector(".button");
        private By YesRadioButton => By.CssSelector("input[name='RemoveOrganisation']");
        #endregion

        public RemoveOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourOrganisationsAndAgreementsPage SelectYesRadioOptionAndClickContinueInRemoveOrganisationPage()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(YesRadioButton));
            Continue();
            return new YourOrganisationsAndAgreementsPage(_context);
        }
    }
}