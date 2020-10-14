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
        private readonly ConsolidateSupportDataHelper _dataHelper;
        private readonly ConsolidatedSupportConfig _config;
        private readonly ObjectContext _objectContext;
        private HomePage _homePage;
        private TicketPage _ticketpage;


        public ExistingUserSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            _dataHelper = context.Get<ConsolidateSupportDataHelper>();
            _restApiHelper = new RestApiHelper(_config, _dataHelper);
        }

        [Given(@"an existing user emails the helpdesk")]
        public void GivenAnExistingUserEmailsTheHelpdesk()
        {
            //var ticket = await _restApiHelper.CreateTicket();

            //_objectContext.SetTicketId($"{ticket.Id}");

            //TestContext.Progress.WriteLine($"Ticket {ticket.Id} created - {ticket.Url}");

            _dataHelper.OrganisationName = _config.OrganisationName;

            _dataHelper.OrganisationUserName = _config.OrganisationUserName;

            _homePage = new SignInPage(_context).SignIntoApprenticeshipServiceSupport();

            _objectContext.SetTicketId("3810");
        }

        [Then(@"a (New|Open) status ticket is displayed")]
        public void ThenStatusTicketIsDisplayed(string status)
        {
            _homePage = new HomePage(_context, true);

            _ticketpage = _homePage.SearchTicket();

            _ticketpage.VerifyTicketStatus(status);
        }

        [When(@"the ticket is submit as open")]
        public void WhenTheTicketIsSubmitAsOpen()
        {
            _homePage = _ticketpage.SubmitAsOpen("Comment - Submit as Open");

            _homePage.SearchTicket();

            _ticketpage.VerifyComments("Comment - Submit as Open");
        }

        [When(@"the ticket is submit as On-Hold")]
        public void WhenTheTicketIsSubmitAsOn_Hold()
        {
            
        }

    }
}
