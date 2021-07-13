using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.MailinatorPages;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MailinatorSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;

        public MailinatorSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Then(@"confirm the user is able to verify the email '(.*)'")]
        public void ThenConfirmTheUserIsAbleToVerifyTheEmail(string organisationEmailAddress)
        {
            _tabHelper.OpenInNewTab(UrlConfig.Mailinator_BaseUrl);
            new MailinatorLandingPage(_context).EnterEmailAndClickOnGoButton(organisationEmailAddress)
                .ClickOnEmail()
                .VerifyEmailLink();
        }
    }
}
