using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouCantConfirmYourEmployerPage : YouCantConfirmBasePage
    {
        protected override string PageTitle => "You have confirmed that this is not your employer.";

        public YouCantConfirmYourEmployerPage(ScenarioContext context) : base(context) { }
    }
}
