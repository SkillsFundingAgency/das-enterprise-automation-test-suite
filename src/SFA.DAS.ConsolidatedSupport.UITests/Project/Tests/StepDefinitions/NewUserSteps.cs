using NUnit.Framework;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NewUserSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [Given(@"a new user without contact and organisation details is created")]
        public void GivenANewUserWithoutContactAndOrganisationDetailsIsCreated()
        {
            var _config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();

            var _dataHelper = context.Get<ConsolidateSupportDataHelper>();

            new SignInPage(context).SignIntoApprenticeshipServiceSupport();

            var user = new RestApiHelper(_config, _dataHelper).CreateUser().Result;

            _objectContext.SetUserId($"{user.Id}");

            TestContext.Progress.WriteLine($"Ticket {user.Id} created - {user.Name}");

            _objectContext.SetUserCreated();
        }

        [Then(@"the user contact details can be updated on the Zendesk portal")]
        public void ThenTheUserContactDetailsCanBeUpdatedOnTheZendeskPortal()
        {
            GoToUserPage().EnterDetails().VerifyDetails();
        }

        [Then(@"the user organisation details can be updated on Zendesk portal")]
        public void ThenTheUserOrganisationDetailsCanBeUpdatedOnZendeskPortal()
        {
            GoToUserPage().CreateOrganisation();

            _objectContext.SetOrgCreated();

            new OrganisationListPage(context).VerifyOrganisationDetails();

            GoToUserPage().VerifyOrganisationDetails();

            new OrgPage(context, true).EnterDetails().VerifyDetails();
        }

        private UserPage GoToUserPage() => new(context);
    }
}