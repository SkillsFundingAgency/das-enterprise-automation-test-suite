using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouCantConfirmYourDetailsPage : YouCantConfirmBasePage
    {
        protected override string PageTitle => "You have confirmed that your apprenticeship details are not correct.";

        public YouCantConfirmYourDetailsPage(ScenarioContext context) : base(context) { }
    }
}
