using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class HowAreTheyCommunicatedToEmployeesPage : RoatpBasePage
    {
        protected override string PageTitle => "How are these quality and high standards in apprenticeship training communicated to employees?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        public HowAreTheyCommunicatedToEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterHowAreTheyCommunicatedToEmployees()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.HowAreTheyCommunicatedToEmployees);
            return new ApplicationOverviewPage(_context);
        }
    }
}