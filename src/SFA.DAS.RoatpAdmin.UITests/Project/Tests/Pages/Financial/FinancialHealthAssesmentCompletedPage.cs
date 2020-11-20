using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssesmentCompletedPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Financial health assessment completed";
        private By GoToRoATPFinancialApplicationsLink => By.LinkText("Back to RoATP financial applications");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialHealthAssesmentCompletedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinancialLandingPage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPFinancialApplicationsLink);
            return new FinancialLandingPage(_context);
        }
    }
}
