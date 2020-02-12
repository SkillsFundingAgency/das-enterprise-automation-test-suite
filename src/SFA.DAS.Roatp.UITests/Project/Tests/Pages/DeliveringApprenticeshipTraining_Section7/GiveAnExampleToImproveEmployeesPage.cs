using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class GiveAnExampleToImproveEmployeesPage : RoatpBasePage
    {
        protected override string PageTitle => "Give an example of how your organisation used this policy to improve employee sector expertise";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.CssSelector("textarea");

        public GiveAnExampleToImproveEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public GiveAnExampleToMaintainEmployeesPage EnterAnExampleToImproveEmployees()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.ExampleToImproveEmployees);
            Continue();
            return new GiveAnExampleToMaintainEmployeesPage(_context);
        }
    }
}