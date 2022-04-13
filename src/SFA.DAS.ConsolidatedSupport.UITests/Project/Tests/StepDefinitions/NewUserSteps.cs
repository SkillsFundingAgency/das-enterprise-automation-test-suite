using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.StepDefinitions
{
    public class NewUserSteps
    {
        private readonly ScenarioContext _context;
        private readonly RestApiHelper _restApiHelper;
        private readonly ConsolidateSupportDataHelper _dataHelper;
        private readonly ConsolidatedSupportConfig _config;
        private readonly ObjectContext _objectContext;
        private UserPage _userPage;

        public NewUserSteps(ScenarioContext context)
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
            new SignInPage(_context).SignIntoApprenticeshipServiceSupport();

            var user = _restApiHelper.CreateUser().Result;

            _objectContext.SetUserId($"{user.Id}");

            TestContext.Progress.WriteLine($"Ticket {user.Id} created - {user.Name}");

            _objectContext.SetUserCreated();
        }

        [Then(@"the user contact details can be updated on the Zendesk portal")]
        public void ThenTheUserContactDetailsCanBeUpdatedOnTheZendeskPortal()
        {
            new UserPage(_context).EnterDetails().VerifyDetails();
        }

        [Then(@"the user organisation details can be updated on Zendesk portal")]
        public void ThenTheUserOrganisationDetailsCanBeUpdatedOnZendeskPortal()
        {
            _userPage = new UserPage(_context);

            _userPage.CreateOrganisation();

            _objectContext.SetOrgCreated();

            _userPage.VerifyOrganisationDetails();

            new OrgPage(_context, true).EnterDetails().VerifyDetails();
        }

    }
}
