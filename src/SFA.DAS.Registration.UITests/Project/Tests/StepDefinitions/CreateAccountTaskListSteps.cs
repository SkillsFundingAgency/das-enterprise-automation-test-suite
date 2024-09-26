using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountTaskListSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private readonly AccountCreationTaskListStepsHelper _accountCreationTaskListStepsHelper;
        
        private StubAddYourUserDetailsPage _stubAddYourUserDetailsPage;
        private ConfirmYourUserDetailsPage _confirmYourUserDetailsPage;
        private CreateYourEmployerAccountPage _createYourEmployerAccountPage;

        public CreateAccountTaskListSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
            _accountCreationTaskListStepsHelper = new AccountCreationTaskListStepsHelper(context);
        }

        [StepArgumentTransformation(@"(can|cannot)")]
        public static bool CanToBool(string value)
        {
            return value == "can";
        }

        [StepArgumentTransformation(@"(does|doesn't)")]
        public static bool DoesToBool(string value)
        {
            return value == "does";
        }

        [When(@"user logs out and log back in")]
        public void WhenUserLogsOutAndLogsBackIn()
        {
            var loggedInAccountUser = _objectContext.GetLoginCredentials();
            _createYourEmployerAccountPage.SignOut()
                .CickContinueInYouveLoggedOutPage()
                .GoToStubSignInPage()
                .Login(loggedInAccountUser.Username, loggedInAccountUser.IdOrUserRef).Continue();
        }

        [Then(@"user can resume employer registration journey")]
        public void UserCanResumeEmployerRegistrationJourney()
        {
            _createYourEmployerAccountPage.CheckIsPageCurrent();
        }

        [Given(@"user logs into stub")]
        public StubAddYourUserDetailsPage UserLogsIntoStub() => _stubAddYourUserDetailsPage = _accountCreationStepsHelper.UserLogsIntoStub();

        [Then(@"User is prompted to enter first and last name")]
        public ConfirmYourUserDetailsPage UserEntersNameAndContinue() => _confirmYourUserDetailsPage = _accountCreationTaskListStepsHelper.UserEntersNameAndContinue(_stubAddYourUserDetailsPage);

        [Then(@"user can amend name before submitting it")]
        public ConfirmYourUserDetailsPage UserAmendsNameThenSubmits() => _confirmYourUserDetailsPage = _accountCreationTaskListStepsHelper.UserChangesUserDetails(_confirmYourUserDetailsPage);

        [When(@"user adds name successfully to the account")]
        [Then(@"user adds name successfully to the account")]
        public CreateYourEmployerAccountPage UserConfirmsNameAndAcknowledges() => _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.UserClicksContinueButtonToAcknowledge(_confirmYourUserDetailsPage);

        [Then(@"user can change user details from the task list")]
        public CreateYourEmployerAccountPage UserChangesUserDetailsFromTaskList() => _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.UserChangesDetailsFromTaskList(_createYourEmployerAccountPage);

        [When(@"user (.*) add PAYE details")]
        public CreateYourEmployerAccountPage UserCanAddPAYEFromTaskList(bool doesAdd)
        {
            if (doesAdd)
            {
                _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.AddPAYEFromTaskListForCloseTo3Million(_createYourEmployerAccountPage);
            }

            _createYourEmployerAccountPage = doesAdd
                ? AccountCreationTaskListStepsHelper.UserCannotAmendPAYEScheme(_createYourEmployerAccountPage)
                : AccountCreationTaskListStepsHelper.UserCanClickAddAPAYEScheme(_createYourEmployerAccountPage);


            return _createYourEmployerAccountPage;
        }

        [When(@"user (.*) set account name and (.*)")]
        public CreateYourEmployerAccountPage UserCanSetAccountNameFromTaskList(bool canSetAccountName, bool doesSet)
        {
            _createYourEmployerAccountPage = canSetAccountName
                ? AccountCreationTaskListStepsHelper.UserCanClickAddAccountName(_createYourEmployerAccountPage)
                : AccountCreationTaskListStepsHelper.UserCannotClickAccountName(_createYourEmployerAccountPage);

            if (canSetAccountName && doesSet)
            {
                _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.ConfirmEmployerAccountName(_createYourEmployerAccountPage);
            }
            return _createYourEmployerAccountPage;
        }

        [Then(@"user can update account name")]
        public CreateYourEmployerAccountPage UserCanUpdateAccountName()
        {
            _createYourEmployerAccountPage = _accountCreationTaskListStepsHelper.UpdateEmployerAccountName(_createYourEmployerAccountPage);
            return _createYourEmployerAccountPage;
        }

        [When(@"user acknowledges the employer agreement")]
        public CreateYourEmployerAccountPage UserAcknowledgesEmployerAgreement()
        {
            _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.UserAcknowledgesEmployerAgreement(_createYourEmployerAccountPage);
            return _createYourEmployerAccountPage;
        }

        [When(@"user (.*) accept the employer agreement and (.*)")]
        public CreateYourEmployerAccountPage UserCanAcceptEmployerAgreement(bool canAcceptAgreement, bool doesAccept)
        {
            _createYourEmployerAccountPage = canAcceptAgreement
               ? AccountCreationTaskListStepsHelper.UserCanClickAcceptEmployerAgreement(_createYourEmployerAccountPage)
               : AccountCreationTaskListStepsHelper.UserCannotClickAcceptEmployerAgreement(_createYourEmployerAccountPage);

            if (canAcceptAgreement && doesAccept)
            {
                return _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.AcceptEmployerAgreement(_createYourEmployerAccountPage);
            }
            return _createYourEmployerAccountPage;
        }

        [Then(@"user accepts agreement having already acknowledged")]
        public CreateYourEmployerAccountPage UserCanAcceptEmployerAgreement()
        {
            return _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.AcceptEmployerAgreementWhenAlreadyAcknowledged(_createYourEmployerAccountPage);
        }

        [When(@"user (.*) add training provider and (.*)")]
        public CreateYourEmployerAccountPage UserCanAddTrainingProvider(bool canAddTrainingProvider, bool doesAdd)
        {
            _createYourEmployerAccountPage = canAddTrainingProvider
               ? AccountCreationTaskListStepsHelper.UserCanClickTrainingProvider(_createYourEmployerAccountPage)
               : AccountCreationTaskListStepsHelper.UserCannotClickTrainingProvider(_createYourEmployerAccountPage);


            if (canAddTrainingProvider && doesAdd)
            {
                _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.AddTrainingProvider(_createYourEmployerAccountPage, _context.GetProviderConfig<ProviderConfig>().Ukprn);
            }
            return _createYourEmployerAccountPage;
        }

        [When(@"user (.*) grant training provider permissions and (.*)")]
        public void UserCanGrantProviderPermissions(bool canAddPermissions, bool doesGrant)
        {
            _createYourEmployerAccountPage = canAddPermissions
               ? AccountCreationTaskListStepsHelper.UserCanClickTrainingProviderPermissions(_createYourEmployerAccountPage)
               : AccountCreationTaskListStepsHelper.UserCannotClickTrainingProviderPermissions(_createYourEmployerAccountPage);

            if (canAddPermissions && doesGrant)
            {
                AccountCreationTaskListStepsHelper.GrantTrainingProviderPermissions(_createYourEmployerAccountPage);
            }
        }
        
        [When(@"user (.*) add training provider and (.*), the user (.*) grant training provider permissions")]
        public void UserAddTrainingProviderAndGrantPermission(bool canAddTrainingProvider, bool doesAdd, bool doesGrant)
        {
            _createYourEmployerAccountPage = canAddTrainingProvider
              ? AccountCreationTaskListStepsHelper.UserCanClickTrainingProvider(_createYourEmployerAccountPage)
              : AccountCreationTaskListStepsHelper.UserCannotClickTrainingProvider(_createYourEmployerAccountPage);


            if (canAddTrainingProvider && doesAdd)
            {
                _createYourEmployerAccountPage = AccountCreationTaskListStepsHelper.AddTrainingProvider(_createYourEmployerAccountPage, _context.GetProviderConfig<ProviderConfig>().Ukprn);
            }

            if (doesGrant)
            {
                AccountCreationTaskListStepsHelper.GrantTrainingProviderPermissions(_createYourEmployerAccountPage);
            }

        }

    }
}
