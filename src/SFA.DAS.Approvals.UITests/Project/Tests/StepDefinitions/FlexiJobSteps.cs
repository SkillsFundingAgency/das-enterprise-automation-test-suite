using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiJobSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private AddPersonalDetailsPage _addApprenticeDetailsPage;
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private readonly FlexiJobUser _fjaaEmployerLevyUser;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;

        public FlexiJobSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _fjaaEmployerLevyUser = context.GetUser<FlexiJobUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _fjaaEmployerLevyUser);
        }

        [Given(@"an employer who is on Flexi-job agency register logins using exisiting Levy Account")]
        public void GivenAnEmployerWhoIsOnFlexi_JobAgencyRegisterLoginsUsingExisitingLevyAccount() => _multipleAccountsLoginHelper.Login(_fjaaEmployerLevyUser, true);

        [When(@"employer selects Flexi-job agency radio button on Select Delivery Model screen")]
        public void GivenEmployerSelectsFlexi_JobAgencyRadioButtonOnSelectDeliveryModelScreen()
        {
            _addApprenticeDetailsPage = _employerStepsHelper.FlexiEmployerAddsApprenticeAndSelectsFlexiJobAgencyDeliveryModel();
        }

        [When(@"employer selects Regular radio button on Select Delivery Model screen")]
        public void WhenEmployerSelectsRegularRadioButtonOnSelectDeliveryModelScreen()
        {
            _addApprenticeDetailsPage = _employerStepsHelper.FlexiEmployerAddsApprenticeAndSelectsRegularDeliveryModel();
        }


        [Then(@"validate Flexi-job agency content on Add Apprentice Details page and submit valid details")]
        public void ThenValidateFlexi_JobAgencyContentOnAddApprenticeDetailsPageAndSubmitValidDetails()
        {
            var addTrainingDetailsPage = _addApprenticeDetailsPage.SubmitValidPersonalDetails();
            addTrainingDetailsPage.ValidateFlexiJobContent();

            _approveApprenticeDetailsPage = addTrainingDetailsPage.SubmitValidTrainingDetails(false);
        }

        [Then(@"validate Regular content on Add Apprentice Details page and submit valid details")]
        public void ThenValidateRegularContentOnAddApprenticeDetailsPageAndSubmitValidDetails()
        {
            var addTrainingDetailsPage = _addApprenticeDetailsPage.SubmitValidPersonalDetails();
            addTrainingDetailsPage.ValidateRegularContent();

            _approveApprenticeDetailsPage = addTrainingDetailsPage.SubmitValidTrainingDetails(false);
        }


        [Then(@"validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review")]
        public void ThenValidateFlexi_JobAgencyTagOnApproveApprenticeDetailsPageAndSendCohortToProviderForReview()
        {
            _approveApprenticeDetailsPage.validateFlexiJobAgencyTag();
            var cohortReference = _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            _objectContext.SetCohortReference(cohortReference);
            _objectContext.SetNoOfApprentices(1);
        }

        [Then(@"validate Flexi-job agency tag is not displayed on Approve Apprentice Details page and send cohort to provider for review")]
        public void ThenValidateFlexi_JobAgencyTagIsNotDisplayedOnApproveApprenticeDetailsPageAndSendCohortToProviderForReview()
        {
            _approveApprenticeDetailsPage.ValidateFlexiTagNotDisplayed();
            var cohortReference = _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            _objectContext.SetCohortReference(cohortReference);
            _objectContext.SetNoOfApprentices(1);
        }

    }
}
