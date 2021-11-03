using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Mailinator.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MailinatorSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationConfig _config;

        public MailinatorSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _config = _context.GetRegistrationConfig<RegistrationConfig>();
        }

        [Then(@"the User receives Access code notification to the registered email")]
        public void TheUserReceivesAccessCodeNotificationToTheRegisteredEmail() => new MailinatorStepsHelper(_context, _objectContext.GetRegisteredEmail()).VerifyAccessCode(_config.RE_ConfirmCode);
    }
}
