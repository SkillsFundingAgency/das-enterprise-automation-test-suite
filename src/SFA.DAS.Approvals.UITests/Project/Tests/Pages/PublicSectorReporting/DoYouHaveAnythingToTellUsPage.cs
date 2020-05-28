using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DoYouHaveAnythingToTellUsPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Do you have anything else you want to tell us?";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouHaveAnythingToTellUsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterCommentsDetails()
        {
            formCompletionHelper.EnterText(Textarea, dataHelper.EmployerComments);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}