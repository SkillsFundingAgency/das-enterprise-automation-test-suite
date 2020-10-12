using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingUserSteps
    {
        private readonly ScenarioContext _context;
        private readonly RestApiHelper _restApiHelper;
        private readonly ConsolidatedSupportConfig _config;
        private readonly ObjectContext _objectContext;

        public ExistingUserSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            _restApiHelper = new RestApiHelper(_config);
        }

        [Given(@"an existing user emails the helpdesk")]
        public async void GivenAnExistingUserEmailsTheHelpdesk()
        {
            var ticket = await _restApiHelper.CreateTicket();

            _objectContext.SetTicketId(ticket.Id);

            TestContext.Progress.WriteLine($"Ticket {ticket.Id} created - {ticket.Url}");
        }

        [Then(@"a New status ticket is displayed")]
        public void ThenANewStatusTicketIsDisplayed()
        {
            new SignInPage(_context).SignIntoApprenticeshipServiceSupport();
        }
    }
}
