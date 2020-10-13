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
        private TicketPage _ticketpage;


        public ExistingUserSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            var datahelper = context.Get<ConsolidateSupportDataHelper>();
            _restApiHelper = new RestApiHelper(_config, datahelper);
        }

        [Given(@"an existing user emails the helpdesk")]
        public async void GivenAnExistingUserEmailsTheHelpdesk()
        {
            var ticket = await _restApiHelper.CreateTicket();

            _objectContext.SetTicketId($"{ticket.Id}");

            TestContext.Progress.WriteLine($"Ticket {ticket.Id} created - {ticket.Url}");
        }

        [Then(@"a New status ticket is displayed")]
        public void ThenANewStatusTicketIsDisplayed()
        {
            _objectContext.SetTicketId("3814");

            _ticketpage = new SignInPage(_context).SignIntoApprenticeshipServiceSupport().SearchTicket();

            StringAssert.AreEqualIgnoringCase("New", _ticketpage.GetTicketStatus());
        }

        [When(@"the ticket is submit as open")]
        public void WhenTheTicketIsSubmitAsOpen()
        {
            _ticketpage.SelectAsOpen();
        }

    }
}
