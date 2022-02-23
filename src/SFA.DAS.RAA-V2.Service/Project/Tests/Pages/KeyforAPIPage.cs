using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class KeyforAPIPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Key for API";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        protected override bool TakeFullScreenShot => false;

        #region Locators
        private readonly By RenewKeyLink = By.Id("renew-key");
        private readonly By DoYouNeedANewKeyDropDown = By.ClassName("govuk-details__summary-text");
        #endregion

        public KeyforAPIPage(ScenarioContext context) : base(context) { }

        public AreYouSureYouWantToRenewThisAPIKeyPage ClickRenewKeyLink()
        {
            formCompletionHelper.Click(RenewKeyLink);
            return new AreYouSureYouWantToRenewThisAPIKeyPage(context);
        }

        public KeyforAPIPage ClickDoYouNeedANewKeyDropDown()
        {
            formCompletionHelper.Click(DoYouNeedANewKeyDropDown);
            return new KeyforAPIPage(context);
        }
    }
}