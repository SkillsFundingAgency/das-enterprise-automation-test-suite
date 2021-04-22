using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class HowManyEmployeesWillDeliverTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How many employees will deliver training ";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");
        private By NumberOfEmployees => By.CssSelector(".govuk-input");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowManyEmployeesWillDeliverTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public MostExperiencedEmployeePage EnterNumberOfEmployeesAndContinue()
        {
            formCompletionHelper.EnterText(NumberOfEmployees, "1234");
            Continue();
            return new MostExperiencedEmployeePage(_context);
        }
    }
}