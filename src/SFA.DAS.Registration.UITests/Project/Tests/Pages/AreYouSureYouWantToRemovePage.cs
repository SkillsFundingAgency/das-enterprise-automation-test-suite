using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AreYouSureYouWantToRemovePage : RegistrationBasePage
    {
        protected override string PageTitle => "Are you sure you want to remove";
        
        #region Locators
        private By YesRadioButton => By.Name("Remove");
        protected override By ContinueButton => By.Id("can-remove-organisation-button");
        #endregion

        public AreYouSureYouWantToRemovePage(ScenarioContext context) : base(context) => VerifyPage();


        public YourOrganisationsAndAgreementsPage SelectYesRadioOptionAndClickContinueInRemoveOrganisationPage()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesRadioButton);
            Continue();          
            return new YourOrganisationsAndAgreementsPage(_context);
        }
    }
}