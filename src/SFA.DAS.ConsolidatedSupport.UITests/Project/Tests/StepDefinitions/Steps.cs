using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Steps
    {
        private readonly ScenarioContext _context;
        private readonly RestApiHelper _restApiHelper;
        private readonly ConsolidateSupportDataHelper _dataHelper;
        private readonly ConsolidatedSupportConfig _config;
        private readonly ObjectContext _objectContext;
        private HomePage _homePage;
        private TicketPage _ticketpage;

        public Steps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            _dataHelper = context.Get<ConsolidateSupportDataHelper>();
            _restApiHelper = new RestApiHelper(_config, _dataHelper);
        }

        [Given(@"a new user without contact and organisation details is created")]
        public void GivenANewUserWithoutContactAndOrganisationDetailsIsCreated()
        {
            _homePage = new SignInPage(_context).SignIntoApprenticeshipServiceSupport();

            var user = _restApiHelper.CreateUser().Result;

            _objectContext.SetUserId($"{user.Id}");

            TestContext.Progress.WriteLine($"Ticket {user.Id} created - {user.Name}");
        }

        [Then(@"the user contact details can be updated on the Zendesk portal")]
        public void ThenTheUserContactDetailsCanBeUpdatedOnTheZendeskPortal()
        {
            var userpage = _homePage.NavigateToAdminPage().NavigateToUserPage();

            _homePage = userpage.SelectOptions("Contact Type", _dataHelper.Type);
            _homePage = userpage.EnterText("Address Line 1", _dataHelper.AddressLine1);
            _homePage = userpage.EnterText("Address Line 2", _dataHelper.AddressLine2);
            _homePage = userpage.EnterText("Address Line 3", _dataHelper.AddressLine3);
            _homePage = userpage.EnterText("City", _dataHelper.City);
            _homePage = userpage.EnterText("Postcode", _dataHelper.Postcode);

            _homePage = userpage.VerifyUserDetails("Contact Type", _dataHelper.Type);
        }

        [Then(@"the user organisation details can be updated on the Zendesk portal")]
        public void ThenTheUserOrganisationDetailsCanBeUpdatedOnZendeskPortal()
        {
            var userpage = _homePage.NavigateToAdminPage().NavigateToUserPage();

            userpage.CreateOrganisation();

            _homePage = userpage.VerifyOrganisationName();

            _homePage = userpage.VerifyOrganisationDomain();

            _homePage = userpage.SelectOptions("Organisation Type", _dataHelper.Type, true);
            _homePage = userpage.SelectOptions("Organisation Status", _dataHelper.Status, true);
            _homePage = userpage.SelectOptions("Account Manager Status", _dataHelper.AccountManagerStatus, true);

            _homePage = userpage.EnterText("Address Line 1", _dataHelper.AddressLine1, true);
            _homePage = userpage.EnterText("Address Line 2", _dataHelper.AddressLine2, true);
            _homePage = userpage.EnterText("Address Line 3", _dataHelper.AddressLine3, true);
            _homePage = userpage.EnterText("City", _dataHelper.City, true);
            _homePage = userpage.EnterText("County", _dataHelper.County, true);
            _homePage = userpage.EnterText("Postcode", _dataHelper.Postcode, true);
            _homePage = userpage.EnterText("Account Manager Name", _dataHelper.NewUserFullName, true);
            _homePage = userpage.EnterText("Account Manager E-mail", _dataHelper.NewUserEmail, true);

            _homePage = userpage.VerifyUserDetails("Organisation Type", _dataHelper.Type, true);
            _homePage = userpage.VerifyUserDetails("Organisation Status", _dataHelper.Status, true);
            _homePage = userpage.VerifyUserDetails("Account Manager Status", _dataHelper.AccountManagerStatus, true);
        }

        [Then(@"the user organisation can be deleted on the Zendesk portal")]
        public void ThenTheUserOrganisationCanBeDeletedOnTheZendeskPortal()
        {
            var homePage = new HomePage(_context, true);

            var userpage = homePage.NavigateToAdminPage().NavigateToUserPage();

            userpage.DeleteEntity(true);
        }

        [Then(@"the user can be deleted on the Zendesk portal")]
        public void ThenTheUserCanBeDeletedOnTheZendeskPortal()
        {
            var homePage = new HomePage(_context, true);

            var userpage = homePage.NavigateToAdminPage().NavigateToUserPage();

            userpage.DeleteEntity();
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
