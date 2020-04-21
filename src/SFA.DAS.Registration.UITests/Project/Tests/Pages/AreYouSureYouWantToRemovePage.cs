using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AreYouSureYouWantToRemovePage : RegistrationBasePage
    {
        protected override string PageTitle => "Are you sure you want to remove";
        private readonly ScenarioContext _context;

        #region Locators
        // Will be uncomment this code in the next sprint
        // private By CantBeRemovedMessageText => By.XPath("//td[text()=\"Can't be removed because it's the only organisation on your account.\"]");
        private By YesRadioButton => By.Name("Remove");
        protected override By ContinueButton => By.Id("can-remove-organisation-button");
        #endregion

        public AreYouSureYouWantToRemovePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        //Will be uncomment this code in the next sprint
        //public AreYouSureYouWantToRemovePage VerifyCantBeRemovedMessageTextOnRemoveAnOrganisationPage()
        //{
        //    VerifyPage(CantBeRemovedMessageText);
        //    return this;
        //}

        public YourOrganisationsAndAgreementsPage SelectYesRadioOptionAndClickContinueInRemoveOrganisationPage()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesRadioButton);
            Continue();          
            return new YourOrganisationsAndAgreementsPage(_context);
        }
    }
}