using TechTalk.SpecFlow;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PaymentsSimplificationNotificationSteps
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly ProviderConfig _providerConfig;
        private readonly ObjectContext _objectContext;


        public PaymentsSimplificationNotificationSteps(ScenarioContext context)
        {
            _context = context;
            _tabHelper = _context.Get<TabHelper>();
            _providerConfig = _context.GetProviderConfig<ProviderConfig>();
            _objectContext = _context.Get<ObjectContext>();
        }

        [When(@"Employer is notified that a provider has requested a price change through email")]
        public void EmployerIsNotifiedThatAProviderHasRequestedAPriceChangeThroughEmail()
        {
            var loggedInEmployerDetails = new LoggedInEmployerDetails(_objectContext);

            var userDetails = loggedInEmployerDetails.GetLoggedInEmployerUserDetails();

            var mailosaurHelper = new MailosaurApiHelper(_context);

            string subject = $"{_providerConfig.Name} requested a price change";

            _tabHelper.OpenInNewTab(_context.Get<MailosaurApiHelper>().GetLinkBySubject(userDetails.Email, subject, $"https://approvals.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/{userDetails.HashedId}/apprentices/"));
        }
    }
}
