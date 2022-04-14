using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
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

        [Given(@"an existing user logs into the helpdesk")]
        public void GivenAnExistingUserLogsIntoTheHelpdesk()
        {
            _dataHelper.OrganisationName = _config.OrganisationName;

            _dataHelper.OrganisationUserName = _config.OrganisationUserName;

            _homePage = new SignInPage(_context).SignIntoApprenticeshipServiceSupport();
        }

        [Given(@"the user emails the helpdesk")]
        public void GivenTheUserEmailsTheHelpdesk()
        {
            var ticket = _restApiHelper.CreateTicket().Result;

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

        [When(@"the ticket is submit as (New|Open|On-Hold|Pending|Solved)")]
        public void WhenTheTicketIsSubmitAs(string status) => SubmitAs(status);

        [Then(@"a service now incident number is populated")]
        public void ThenAServiceNowIncidentNumberIsPopulated() => StringAssert.StartsWith("INC", _ticketpage.GetServiceNowTicket());

        private void VerifySubmittedComments(string comments)
        {
            _ticketpage = _homePage.SearchTicket();

            _ticketpage.VerifySubmittedComments(comments.Trim());
        }

        private void SubmitAs(string status)
        {
            switch (true)
            {
                case bool _ when status.IsNew(): SubmitAs((x) => x.SubmitAsNew()); break;
                case bool _ when status.IsOpen(): SubmitAs((x) => x.SubmitAsOpen()); break;
                case bool _ when status.IsOnHold(): SubmitAs((x) => x.SubmitAsOnHold()); break;
                case bool _ when status.IsPending(): SubmitAs((x) => x.SubmitAsPending()); break;
                case bool _ when status.IsSolved(): SubmitAs((x) => x.SubmitAsSolved()); break;
                default: break;
            }
        }

        private void SubmitAs(Func<TicketPage, (HomePage, string)> func)
        {
            (HomePage homePage, string comments) = func(_ticketpage);

            _homePage = homePage;

            VerifySubmittedComments(comments);
        }

    }
}
