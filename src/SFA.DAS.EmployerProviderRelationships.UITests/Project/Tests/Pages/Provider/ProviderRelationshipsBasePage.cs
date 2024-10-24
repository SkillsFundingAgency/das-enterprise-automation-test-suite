using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public abstract class ProviderRelationshipsBasePage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected readonly EprDataHelper eprDataHelper = context.Get<EprDataHelper>();
    }
}
