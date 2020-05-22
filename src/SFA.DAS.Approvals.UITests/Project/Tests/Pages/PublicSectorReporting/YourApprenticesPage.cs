using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourApprenticesPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your apprentices";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterApprenticeDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of apprentices who were working in England on 31 March 2019", dataHelper.NoofApprentices2019);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of apprentices who were working in England on 31 March 2020", dataHelper.NoofApprentices2020);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of new apprentices who started working for you in England between 1 April 2019 to 31 March 2020", dataHelper.NoofNewApprentices);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}