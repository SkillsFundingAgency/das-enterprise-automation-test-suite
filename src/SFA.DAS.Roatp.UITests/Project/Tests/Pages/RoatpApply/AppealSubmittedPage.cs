using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class AppealSubmittedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Appeal ";

        public AppealSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();

        public AppealSubmittedPage VerifyAppealOutcomePage(string expectedPage)
        {
            pageInteractionHelper.VerifyText(PageHeader, expectedPage);
            return this;
        }

        public ApplicationOutcomePage AccessApplicationOverviewPage()
        {
            formCompletionHelper.ClickLinkByText("Application overview");
            return new ApplicationOutcomePage(context);
        }

    }
}
