using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouCantConfirmYourEmployerPage(ScenarioContext context) : YouCantConfirmBasePage(context)
    {
        protected override string PageTitle => "You have confirmed that this is not your employer.";
    }
}
