using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.EPAOStandardCancellationPages
{
    public class AP_OSC01_AreYouSureYouWantToCancelThisStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Are you sure you want to cancel your application to assess this standard?";

        private readonly ScenarioContext _context;
        private readonly JavaScriptHelper _javaScriptHelper;

        #region Locators
        private By ClickYesToCancelStandard => By.Id("AreYouSure");
        #endregion

        public AP_OSC01_AreYouSureYouWantToCancelThisStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            _javaScriptHelper = _context.Get<JavaScriptHelper>();
        }

        public AP_OSC02_YouHaveCancelledYourApplicationPage SelectYesToCancelStandardApplication()
        {
            _javaScriptHelper.ClickElement(ClickYesToCancelStandard);
            Continue();
            return new AP_OSC02_YouHaveCancelledYourApplicationPage(_context);
        }       
    }
}