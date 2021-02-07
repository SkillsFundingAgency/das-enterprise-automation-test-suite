using OpenQA.Selenium;
using TechTalk.SpecFlow;
namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.EPAOStandardCancellationPages
{
    public class AP_OSC01_AreYouSureYouWantToCancelThisStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Are you sure you want to cancel your application to assess this standard?";
        private readonly ScenarioContext _context;

        #region Locators
        private By ClickYesToCancelStandard => By.XPath("//div[@class='govuk-radios']//div[@class='govuk-radios__item']//input[@id='AreYouSure']");
        #endregion

        public AP_OSC01_AreYouSureYouWantToCancelThisStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OSC02_YouHaveCancelledYourApplicationPage SelectYesToCancelStandardApplication()
        {
            //SelectRadioOptionByForAttribute("Yes");
            formCompletionHelper.ClickElement(ClickYesToCancelStandard);
            Continue();
            return new AP_OSC02_YouHaveCancelledYourApplicationPage(_context);
        }       
    }
}