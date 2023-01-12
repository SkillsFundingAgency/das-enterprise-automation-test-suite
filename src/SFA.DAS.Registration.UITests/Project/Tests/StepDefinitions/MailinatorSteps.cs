using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Mailinator.Service.Project.Helpers;
using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
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
        private readonly MailinatorApiHelper _mailinatorApiHelper;
        public MailinatorSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _mailinatorApiHelper = context.Get<MailinatorApiHelper>();
            _config = _context.GetRegistrationConfig<RegistrationConfig>();
        }

        [Then(@"the User receives Access code notification to the registered email")]
        public void TheUserReceivesAccessCodeNotificationToTheRegisteredEmail() => new MailinatorStepsHelper(_context, _objectContext.GetRegisteredEmail()).VerifyAccessCode(_config.RE_ConfirmCode);

        [Then(@"mailinator api can access the inbox")]
        public void ThenMailinatorApiCanAccessTheInbox()
        {
            _mailinatorApiHelper.VerifyAccessCode(_objectContext.GetRegisteredEmail(), _config.RE_ConfirmCode);
        }
    }
}
