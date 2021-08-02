using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouCantConfirmYourTrainingProviderPage : YouCantConfirmBasePage
    {
        protected override string PageTitle => "You have confirmed that this is not your training provider.";

        public YouCantConfirmYourTrainingProviderPage(ScenarioContext context) : base(context) { }
    }
}
