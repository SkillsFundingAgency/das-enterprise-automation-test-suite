using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project.Tests.Pages.Reviewer
{
    public class QAReviewsPage : VerifyDetailsBasePage
    {
        public QAReviewsPage(ScenarioContext context) : base(context, false) => pageInteractionHelper.WaitforURLToChange("reviews");

        protected override string PageTitle { get; }
    }
}
