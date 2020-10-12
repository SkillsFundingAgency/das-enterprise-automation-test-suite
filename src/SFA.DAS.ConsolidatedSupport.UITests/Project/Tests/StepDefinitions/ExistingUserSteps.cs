using NUnit.Framework;
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

        public ExistingUserSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            _restApiHelper = new RestApiHelper(_config);
        }

        [Given(@"an existing user emails the helpdesk")]
        public async void GivenAnExistingUserEmailsTheHelpdesk()
        {
            var ticket = await _restApiHelper.CreateTicket();

            TestContext.Progress.WriteLine($"Ticket {ticket.Id} created - {ticket.Url}");

            new SignInPage(_context).SignIntoApprenticeshipServiceSupport();
        }

    }
}
