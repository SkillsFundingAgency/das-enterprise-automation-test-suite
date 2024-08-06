using System;
using Polly;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    public class TasksSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private readonly TprSqlDataHelper _tprSqlDataHelper;
        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private readonly TasksHelper _tasksHelper;

        private HomePage _homePage;
        private AddAPAYESchemePage _addAPAYESchemePage;
        private GgSignInPage _gGSignInPage;
        private SearchForYourOrganisationPage _searchForYourOrganisationPage;
        private SelectYourOrganisationPage _selectYourOrganisationPage;
        private CheckYourDetailsPage _checkYourDetailsPage;
        private TheseDetailsAreAlreadyInUsePage _theseDetailsAreAlreadyInUsePage;
        private EnterYourPAYESchemeDetailsPage _enterYourPAYESchemeDetailsPage;
        private UsingYourGovtGatewayDetailsPage _usingYourGovtGatewayDetailsPage;
        private CreateAnAccountToManageApprenticeshipsPage _indexPage;
        private AddPayeSchemeUsingGGDetailsPage _addPayeSchemeUsingGGDetailsPage;
        private DoYouAcceptTheEmployerAgreementOnBehalfOfPage _doYouAcceptTheEmployerAgreementOnBehalfOfPage;

        private const string LevyDeclarationDueKey = "LevyDeclarationDue";
        private DateTime CurrentDate = DateTime.UtcNow;

        public TasksSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            _tprSqlDataHelper = context.Get<TprSqlDataHelper>();
            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
            _tasksHelper = new TasksHelper(context);
        }

        [When(@"the current date is in range 16 - 19")]
        public void WhenTheCurrentDateIsInRange()
        {
            var currentDay = CurrentDate.Day;

            _context.Set(currentDay >= 16 && currentDay <= 19, LevyDeclarationDueKey);
            
        }

        [Then(@"display task: 'Levy declaration due by 19 <MMMM>'")]
        public void ThenDisplayTaskLevyDeclarationDueBy()
        {
            bool showLevyDeclarationMessage = _context.ContainsKey(LevyDeclarationDueKey) && (bool)_context[LevyDeclarationDueKey];

            if (showLevyDeclarationMessage)
            {
                _homePage.VerifyLevyDeclarationDueTaskMessageShown();
            }           
        }

        [When(@"there are X apprentice change(s) to review")]
        public void WhenThereAreApprenticeChangesToReview()
        {
            //run a sql query to find out how many changes there should be 

            //then verify message on page IF x > 0

        }
    }
}
