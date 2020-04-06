using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRegistration
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _dataHelper;

        public ProviderRegistration(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<RegistrationDataHelper>();
        }

        [Then(@"the provider can invite an employer")]
        public void ThenTheProviderCanInviteAnEmployer()
        {
            throw new PendingStepException();
        }
    }
}
