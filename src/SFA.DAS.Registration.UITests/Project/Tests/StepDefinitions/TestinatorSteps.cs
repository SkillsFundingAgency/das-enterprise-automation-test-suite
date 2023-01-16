using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "testinator")]
    public class TestinatorSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationConfig _config;

        public TestinatorSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _config = _context.GetRegistrationConfig<RegistrationConfig>();
        }

        [Then(@"the User receives Access code notification to the registered email")]
        public void TheUserReceivesEmail() 
        {
            var _mailinatorApiHelper = _context.Get<MailinatorApiHelper>();

            _mailinatorApiHelper.VerifyEmail(_objectContext.GetRegisteredEmail(), _config.RE_ConfirmCode);
        }

    }
}
