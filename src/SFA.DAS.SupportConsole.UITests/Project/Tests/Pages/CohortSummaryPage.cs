using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CohortSummaryPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Cohort Summary";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        public By CohortRefNumber => By.XPath("//td[text()='Cohort reference']/following-sibling::td");
        private By ViewThisCohortButton => By.Id("viewCohort");
        #endregion

        public CohortSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CohortDetailsPage ClickViewThisCohortButton()
        {
            formCompletionHelper.Click(ViewThisCohortButton);
            return new CohortDetailsPage(_context);
        }

        public string GetCohortRefNumber()
        {
            return pageInteractionHelper.GetText(CohortRefNumber);
        }
    }
}