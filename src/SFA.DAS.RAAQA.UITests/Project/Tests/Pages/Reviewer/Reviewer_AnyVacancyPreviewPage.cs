using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_AnyVacancyPreviewPage : ApproveVacancyBasePage
    {
        protected override string PageTitle => "";

        public Reviewer_AnyVacancyPreviewPage(ScenarioContext context) : base(context, false) => VerifyPage(SubmitButton);
    }
}
