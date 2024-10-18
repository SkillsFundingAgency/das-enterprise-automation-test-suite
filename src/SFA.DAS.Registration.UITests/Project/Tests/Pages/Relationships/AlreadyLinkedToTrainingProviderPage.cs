using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public class AlreadyLinkedToTrainingProviderPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override string PageTitle => "You're already linked to this training provider";

        public void CannotAddExistingTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Return to your training providers");
        }
    }
}
