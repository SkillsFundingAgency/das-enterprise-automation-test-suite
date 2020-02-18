using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class GiveAnExampleToMaintainEmployeesPage : RoatpBasePage
    {
        protected override string PageTitle => "Give an example of how your organisation used this policy to maintain employee teaching and training knowledge";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GiveAnExampleToMaintainEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterAnExampleToMaintainEmployee()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ExampleToMaintainEmployees);
            return new ApplicationOverviewPage(_context);
        }
    }
}