using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class HowAreYouPlanningToMeetTheTargetPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "How are you planning to meet the target in future? What will you continue to do or do differently?";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowAreYouPlanningToMeetTheTargetPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterPlanningDetails()
        {
            formCompletionHelper.EnterText(Textarea, dataHelper.EmployerPlanning);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}