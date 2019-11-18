using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CohortSummaryPage : BasePage
    {
        protected override string PageTitle => "Cohort Summary";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        public By CohortRefNumber => By.XPath("//td[text()='Cohort reference']/following-sibling::td");
        private By ViewThisCohortButton => By.Id("viewCohort");
        #endregion

        public CohortSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void IsPageDisplayed()
        {
            VerifyPage();
        }

        public CohortDetailsPage ClickViewThisCohortButton()
        {
            _formCompletionHelper.Click(ViewThisCohortButton);
            return new CohortDetailsPage(_context);
        }
    }
}