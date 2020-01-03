using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_AnyVacancyPreviewPage : ApproveVacancyBasePage
    {
        protected override string PageTitle => "";
        public Reviewer_AnyVacancyPreviewPage(ScenarioContext context) : base(context)
        {
            VerifyPage(SubmitButton);
        }
    }
}
