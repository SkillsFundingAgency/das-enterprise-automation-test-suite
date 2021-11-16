using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class AppealSubmittedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Appeal ";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AppealSubmittedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AppealSubmittedPage VerifyAppealOutcomePage(string expectedPage)
        {
            pageInteractionHelper.VerifyText(PageHeader, expectedPage);
            return this;
        }

        public ApplicationOutcomePage AccessApplicationOverviewPage()
        {
            formCompletionHelper.ClickLinkByText("Application overview");
            return new ApplicationOutcomePage(_context);
        }

    }
}
