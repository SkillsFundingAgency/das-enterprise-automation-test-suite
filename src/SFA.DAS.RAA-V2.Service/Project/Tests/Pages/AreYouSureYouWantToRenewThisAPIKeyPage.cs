using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AreYouSureYouWantToRenewThisAPIKeyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to renew this API key?";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.CssSelector("#continue-renew-key");

        #region Locators
        private By SelectYesRadioButton => By.CssSelector("#ConfirmRenew-yes");
        private By SelectNoRadioButton => By.CssSelector("#ConfirmRenew-no");
        #endregion

        public AreYouSureYouWantToRenewThisAPIKeyPage(ScenarioContext context) : base(context) { }

        public KeyforAPIPage RenewAPIKey() => GoToKeyforAPIPage(SelectYesRadioButton);
        
        public KeyforAPIPage DoNotRenewApiKey() => GoToKeyforAPIPage(SelectNoRadioButton);
        
        private KeyforAPIPage GoToKeyforAPIPage(By by)
        {
            formCompletionHelper.SelectRadioOptionByLocator(by);
            Continue();
            return new KeyforAPIPage(context);
        }
    }
}
