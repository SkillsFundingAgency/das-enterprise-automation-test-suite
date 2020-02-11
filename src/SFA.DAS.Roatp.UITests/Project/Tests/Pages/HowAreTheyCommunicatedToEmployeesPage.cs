using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class HowAreTheyCommunicatedToEmployeesPage : RoatpBasePage
    {
        protected override string PageTitle => "How are these quality and high standards in apprenticeship training communicated to employees?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.CssSelector("textarea");

        public HowAreTheyCommunicatedToEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterHowAreTheyCommunicatedToEmployees()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.HowAreTheyCommunicatedToEmployees);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}


