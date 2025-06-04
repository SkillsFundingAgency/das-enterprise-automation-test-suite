using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class KeyforApiPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Key for API";

        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        private static By AdvertsLink => By.LinkText("Adverts");

        #region Locators
        private readonly By RenewKeyLink = By.CssSelector("#renew-key");
        private readonly By DoYouNeedANewKeyDropDown = By.CssSelector(".govuk-details__summary-text");

        #endregion

        public KeyforApiPage VerifyApikeyRenewed() { VerifyPanelTitle("Key renewed"); return this; }

        public AreYouSureYouWantToRenewThisAPIKeyPage ClickRenewKeyLink()
        {
            formCompletionHelper.Click(DoYouNeedANewKeyDropDown);
            formCompletionHelper.Click(RenewKeyLink);
            return new AreYouSureYouWantToRenewThisAPIKeyPage(context);
        }

        public void ClickAdvertsLink() => formCompletionHelper.Click(AdvertsLink);
    }
}