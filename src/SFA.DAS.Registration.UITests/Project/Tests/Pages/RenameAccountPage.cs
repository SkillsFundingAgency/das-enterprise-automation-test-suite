using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class RenameAccountPage : RegistrationBasePage
    {
        protected override string PageTitle => "Rename account";

        private readonly ScenarioContext _context;

        #region Locators
        private By NewAccountNameTextBox => By.Id("NewName");
        protected override By ContinueButton => By.Id("accept");
        #endregion

        public RenameAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage EnterNewNameAndContinue(string newOrgName)
        {
            formCompletionHelper.EnterText(NewAccountNameTextBox, newOrgName);
            objectContext.UpdateOrganisationName(newOrgName);
            Continue();
            return new HomePage(_context);
        }
    }
}