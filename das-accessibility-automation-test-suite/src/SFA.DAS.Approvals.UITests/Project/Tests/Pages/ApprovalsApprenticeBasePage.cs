using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public abstract class ApprovalsApprenticeBasePage(ScenarioContext context, bool verifypage = true) : ApprovalsBasePage(context, verifypage)
    {
        public ApprenticesHomePage GoBackToApprenticesHomePage()
        {
            formCompletionHelper.Click(BackLink);
            return new ApprenticesHomePage(context);
        }
    }
}