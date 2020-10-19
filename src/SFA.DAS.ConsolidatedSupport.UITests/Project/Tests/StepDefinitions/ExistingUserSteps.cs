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
        public async void GivenAnExistingUserEmailsTheHelpdesk()
        {
            _dataHelper.OrganisationName = _config.OrganisationName;

            _dataHelper.OrganisationUserName = _config.OrganisationUserName;

            _homePage = new SignInPage(_context).SignIntoApprenticeshipServiceSupport();

            var ticket = await _restApiHelper.CreateTicket();

            _objectContext.SetTicketId($"{ticket.Id}");

            TestContext.Progress.WriteLine($"Ticket {ticket.Id} created - {ticket.Url}");
        }

        [Then(@"a (New|Open|On-Hold|Pending|Solved) status ticket is displayed")]
        public void ThenStatusTicketIsDisplayed(string status)
        {
            _homePage = new HomePage(_context, true);

            _ticketpage = _homePage.SearchTicket();

            _ticketpage.VerifyTicketStatus(status);
        }

        [When(@"the ticket is submit as New")]
        public void WhenTheTicketIsSubmitAsNew()
        {
            _homePage = _ticketpage.SubmitAsNew();

            VerifySubmittedComments(_dataHelper.SubmitAsNewComments);
        }


        [When(@"the ticket is submit as open")]
        public void WhenTheTicketIsSubmitAsOpen()
        {
            _homePage = _ticketpage.SubmitAsOpen();

            VerifySubmittedComments(_dataHelper.SubmitAsOpenComments);
        }

        [When(@"the ticket is submit as On-Hold")]
        public void WhenTheTicketIsSubmitAsOn_Hold()
        {
            _ticketpage.SelectOptions("Contact Reason", "Data Lock");
            _ticketpage.SelectOptions("Issue Type", "Query");
            _ticketpage.SelectOptions("Apply macro", "Escalate to Tier 3");

            _ticketpage.VerifyDraftComments("Resolver group to assign to");

            _ticketpage.SelectOptions("Service Offering", "AS Payments");
            _ticketpage.SelectOptions("Resolver Group", "ESFA Apprenticeship Dev Ops");

            _homePage = _ticketpage.SubmitAsOnHold();

            VerifySubmittedComments(_dataHelper.SubmitAsOnHoldComments);
        }

        [When(@"the ticket is submit as Pending")]
        public void WhenTheTicketIsSubmitAsPending()
        {
            _homePage = _ticketpage.SubmitAsPending();

            VerifySubmittedComments(_dataHelper.SubmitAsPendingComments);
        }

        [When(@"the ticket is submit as Solved")]
        public void WhenTheTicketIsSubmitAsSolved()
        {
            _homePage = _ticketpage.SubmitAsSolved();

            VerifySubmittedComments(_dataHelper.SubmitAsSolvedComments);
        }

        [Then(@"a service now incident number is populated")]
        public void ThenAServiceNowIncidentNumberIsPopulated()
        {
            var serviceNowIncidentNumber = _ticketpage.GetServiceNowTicket();

            StringAssert.StartsWith("INC", serviceNowIncidentNumber);
        }


        private void VerifySubmittedComments(string comments)
        {
            _ticketpage = _homePage.SearchTicket();

            _ticketpage.VerifySubmittedComments(comments);
        }
    }
}
