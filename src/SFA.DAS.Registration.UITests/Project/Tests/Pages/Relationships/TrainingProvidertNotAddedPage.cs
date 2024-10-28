using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public class TrainingProvidertNotAddedPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override string PageTitle => "This training provider has not been added to your account";

    }
}
