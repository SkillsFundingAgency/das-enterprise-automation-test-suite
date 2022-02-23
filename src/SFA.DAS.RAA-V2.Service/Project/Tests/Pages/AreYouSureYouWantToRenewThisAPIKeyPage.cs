using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AreYouSureYouWantToRenewThisAPIKeyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to renew this API key?";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private readonly By ViewKeyFirstLink = By.Id("view-key-for-VacanciesManageOuterApi");
        private readonly By SelectYesRadioBUtton = By.Id("ConfirmRenew-yes");
        private readonly By SelectNoRadioBUtton = By.Id("ConfirmRenew-no");
        private readonly By ClickContinueButton = By.Id("continue-renew-key");
        #endregion

        public AreYouSureYouWantToRenewThisAPIKeyPage(ScenarioContext context) : base(context) { }

        public AreYouSureYouWantToRenewThisAPIKeyPage SelectYesToRenewAPIKey()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SelectYesRadioBUtton);
            return new AreYouSureYouWantToRenewThisAPIKeyPage(context);
        }

        public AreYouSureYouWantToRenewThisAPIKeyPage SelectNoNotToRenewAPIKey()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SelectNoRadioBUtton);
            return new AreYouSureYouWantToRenewThisAPIKeyPage(context);
        }

        public KeyforAPIPage ClickContinueToRenewKey()
        {
            formCompletionHelper.Click(ClickContinueButton);
            return new KeyforAPIPage(context);
        }
    }
}
