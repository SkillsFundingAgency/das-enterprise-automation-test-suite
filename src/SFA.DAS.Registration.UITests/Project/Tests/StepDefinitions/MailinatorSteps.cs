using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.MailinatorPages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MailinatorSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly MailinatorConfig _config;

        public MailinatorSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _config = context.GetMailinatorConfig<MailinatorConfig>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Then(@"the User receives Access code notification to the registered email")]
        public void ThenTheUserReceivesAccessCodeNotificationToTheRegisteredEmail()
        {
            _tabHelper.OpenInNewTab(_config.MailinatorURL);
            new MailinatorLandingPage(_context).EnterEmailAndClickOnGoButton(_objectContext.GetRegisteredEmail())
                .ClickOnEmail()
                .VerifyAccessCode("ABC123");
        }
    }
}
