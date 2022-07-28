using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public  class FlexiJobSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private HomePage _homePage;
        private AddApprenticeDetailsPage _addApprenticeDetailsPage;
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;


        public FlexiJobSteps (ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Given(@"an employer who is on Flexi-job agency register logins using exisiting Levy Account")]
        public void GivenAnEmployerWhoIsOnFlexi_JobAgencyRegisterLoginsUsingExisitingLevyAccount() => _homePage = _employerPortalLoginHelper.Login(_context.GetUser<FlexiJobUser>(), true);

        [When(@"employer selects Flexi-job agency radio button on Select Delivery Model screen")]
        public void GivenEmployerSelectsFlexi_JobAgencyRadioButtonOnSelectDeliveryModelScreen()
        {
            _addApprenticeDetailsPage = _employerStepsHelper.FlexiEmployerAddsApprenticeAndSelectsFlexiJobAgencyDeliveryModel();
        }


        [Then(@"validate Flexi-job agency content on Add Apprentice Details page and submit valid details")]
        public void ThenValidateFlexi_JobAgencyContentOnAddApprenticeDetailsPageAndSubmitValidDetails()
        {
            _addApprenticeDetailsPage.ValidateFlexiJobContent();
            _approveApprenticeDetailsPage = _addApprenticeDetailsPage.SubmitValidApprenticeDetails(false);
        }

        [Then(@"validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review")]
        public void ThenValidateFlexi_JobAgencyTagOnApproveApprenticeDetailsPageAndSendCohortToProviderForReview()
        {
            _approveApprenticeDetailsPage.validateFlexiJobAgencyTag();
            var cohortReference = _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            _objectContext.SetCohortReference(cohortReference);
        }






    }
}
