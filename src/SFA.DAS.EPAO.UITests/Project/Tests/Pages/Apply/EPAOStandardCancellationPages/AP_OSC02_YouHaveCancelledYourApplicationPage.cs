using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.EPAOStandardCancellationPages
{
    public class AP_OSC02_YouHaveCancelledYourApplicationPage : EPAO_BasePage
    {
        protected override string PageTitle => "You've cancelled your application to assess standard Brewer (ST0580)";
        private readonly ScenarioContext _context;

        #region Locators
        private By ApplyForAlStandardLink => By.LinkText("apply for a standard");
        #endregion

        public AP_OSC02_YouHaveCancelledYourApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OSC02_YouHaveCancelledYourApplicationPage ClickApplyForAStandardLink()
        {
            formCompletionHelper.Click(ApplyForAlStandardLink);
            return this;
        }
    }
}