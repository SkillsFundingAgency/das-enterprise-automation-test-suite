using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class HowAreYouPlanningToMeetTheTargetPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "How are you planning to meet the target in future? What will you continue to do or do differently?";
        
        public HowAreYouPlanningToMeetTheTargetPage(ScenarioContext context) : base(context)  { }

        public ReportYourProgressPage EnterPlanningDetails()
        {
            formCompletionHelper.EnterText(Textarea, publicSectorReportingDataHelper.EmployerPlanning);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}