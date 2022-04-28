using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AreYouSureYouWantToRenewThisAPIKeyPage : Raav2BasePage
    {
        protected override string PageTitle => "Are you sure you want to renew this API key?";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.CssSelector("#continue-renew-key");

        #region Locators
        private By SelectYesRadioButton => By.CssSelector("#ConfirmRenew-yes");
        private By SelectNoRadioButton => By.CssSelector("#ConfirmRenew-no");
        #endregion

        public AreYouSureYouWantToRenewThisAPIKeyPage(ScenarioContext context) : base(context) { }

        public KeyforApiPage RenewAPIKey() => GoToKeyforAPIPage(SelectYesRadioButton);
        
        public KeyforApiPage DoNotRenewApiKey() => GoToKeyforAPIPage(SelectNoRadioButton);
        
        private KeyforApiPage GoToKeyforAPIPage(By by)
        {
            formCompletionHelper.SelectRadioOptionByLocator(by);
            Continue();
            return new KeyforApiPage(context);
        }
    }
}
