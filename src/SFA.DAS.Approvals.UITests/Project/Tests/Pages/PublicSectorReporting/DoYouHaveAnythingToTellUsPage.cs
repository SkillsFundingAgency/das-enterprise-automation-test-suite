using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class DoYouHaveAnythingToTellUsPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Do you have anything else you want to tell us?";

        public DoYouHaveAnythingToTellUsPage(ScenarioContext context) : base(context)  { }

        public ReportYourProgressPage EnterCommentsDetails()
        {
            formCompletionHelper.EnterText(Textarea, publicSectorReportingDataHelper.EmployerComments);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}