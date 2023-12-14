using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class KeyforApiPage : Raav2BasePage
    {
        protected override string PageTitle => "Key for API";

        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        #region Locators
        private readonly By RenewKeyLink = By.CssSelector("#renew-key");
        private readonly By DoYouNeedANewKeyDropDown = By.CssSelector(".govuk-details__summary-text");
        #endregion

        public KeyforApiPage(ScenarioContext context) : base(context) { }

        public KeyforApiPage VerifyApikeyRenewed() { VerifyPanelTitle("Key renewed"); return this; }

        public AreYouSureYouWantToRenewThisAPIKeyPage ClickRenewKeyLink()
        {
            formCompletionHelper.Click(DoYouNeedANewKeyDropDown);
            formCompletionHelper.Click(RenewKeyLink);
            return new AreYouSureYouWantToRenewThisAPIKeyPage(context);
        }
    }
}