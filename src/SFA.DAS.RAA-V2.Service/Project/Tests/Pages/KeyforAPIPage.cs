using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class KeyforAPIPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Key for API";

        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        #region Locators
        private readonly By RenewKeyLink = By.CssSelector("#renew-key");
        private readonly By DoYouNeedANewKeyDropDown = By.CssSelector(".govuk-details__summary-text");
        #endregion

        public KeyforAPIPage(ScenarioContext context) : base(context) { }

        public KeyforAPIPage VerifyApikeyRenewed() { VerifyPanelTitle("Key renewed"); return this; }

        public AreYouSureYouWantToRenewThisAPIKeyPage ClickRenewKeyLink()
        {
            formCompletionHelper.Click(DoYouNeedANewKeyDropDown);
            formCompletionHelper.Click(RenewKeyLink);
            return new AreYouSureYouWantToRenewThisAPIKeyPage(context);
        }
    }
}