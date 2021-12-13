using OpenQA.Selenium;
using TechTalk.SpecFlow;
namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.EPAOStandardCancellationPages
{
    public class AP_OSC01_AreYouSureYouWantToCancelThisStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Are you sure you want to cancel your application to assess this standard?";

        #region Locators
        private By ClickYesToCancelStandard => By.Id("AreYouSure");
        #endregion

        public AP_OSC01_AreYouSureYouWantToCancelThisStandardPage(ScenarioContext context) : base(context) => VerifyPage();

        public AP_OSC02_YouHaveCancelledYourApplicationPage SelectYesToCancelStandardApplication()
        {
            javaScriptHelper.ClickElement(ClickYesToCancelStandard);
            Continue();
            return new AP_OSC02_YouHaveCancelledYourApplicationPage(_context);
        }       
    }
}