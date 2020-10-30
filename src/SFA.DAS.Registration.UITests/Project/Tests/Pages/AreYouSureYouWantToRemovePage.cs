using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AreYouSureYouWantToRemovePage : RegistrationBasePage
    {
        protected override string PageTitle => "Are you sure you want to remove";
        private readonly ScenarioContext _context;

        #region Locators
        private By YesRadioButton => By.Id("yes");
        protected override By ContinueButton => By.Id("can-remove-organisation-button");
        #endregion

        public AreYouSureYouWantToRemovePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourOrganisationsAndAgreementsPage SelectYesRadioOptionAndClickContinueInRemoveOrganisationPage()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesRadioButton);
            Continue();          
            return new YourOrganisationsAndAgreementsPage(_context);
        }
    }
}