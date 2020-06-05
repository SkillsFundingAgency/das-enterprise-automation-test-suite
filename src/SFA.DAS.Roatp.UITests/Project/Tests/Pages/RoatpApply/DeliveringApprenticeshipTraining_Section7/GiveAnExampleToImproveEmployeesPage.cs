using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class GiveAnExampleToImproveEmployeesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Give an example of how your organisation used this policy to improve employee sector expertise";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GiveAnExampleToImproveEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public GiveAnExampleToMaintainEmployeesPage EnterAnExampleToImproveEmployees()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ExampleToImproveEmployees);
            return new GiveAnExampleToMaintainEmployeesPage(_context);
        }
    }
}