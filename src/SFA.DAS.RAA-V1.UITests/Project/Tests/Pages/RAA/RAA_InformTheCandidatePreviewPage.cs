using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_InformTheCandidatePreviewPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "message has been sent";

        protected override By PageHeader => By.CssSelector(".bold-large");
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_InformTheCandidatePreviewPage(ScenarioContext context) : base(context) 
        {
            _context = context;
        }

        public RAA_VacancySummaryPage ReturnToVacancyApplications()
        {
            formCompletionHelper.ClickButtonByText("Return to vacancy applications");
            return new RAA_VacancySummaryPage(_context);
        }
    }
}
