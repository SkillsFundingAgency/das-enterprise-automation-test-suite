using TechTalk.SpecFlow;
using EmployerStepsHelper = SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers.EmployerStepsHelper;
using ProviderStepsHelper = SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers.ProviderStepsHelper;
using SFA.DAS.Login.Service;
using NUnit.Framework;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerProviderColobarationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private EasAccountUser _loginUser;
        private ProviderVacancySearchResultPage _resultPage;

        public EmployerProviderColobarationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(_context);
        }

        [Given(@"the Employer grants permission to the provider to create advert with review option")]
        public void GivenTheEmployerGrantsPermissionToTheProviderToCreateAdvertWithReviewOption()
        {
            _loginUser = _context.GetUser<RAAV2EmployerProviderPermissionUser>();

            var homePage = _rAAV2EmployerLoginHelper.GoToHomePage(_loginUser);

            EmployerPermissionsStepsHelper.SetAgreementId(homePage, _loginUser.OrganisationName);

            /*
             * these steps are executed as part of test data preparation.
             * 
            _employerPermissionsStepsHelper.RemovePermissisons(_providerPermissionConfig);

            _employerPermissionsStepsHelper.SetRecruitApprenticesPermission(_providerPermissionConfig.Ukprn, loginUser.PermissionOrganisationName);
            */
        }

        [When(@"the Provider submits a vacancy to the employer for review")]
        public void WhenTheProviderSubmitsAVacancyToTheEmployerForReview()
        {
            var vacancyReferencePage = new ProviderCreateVacancyStepsHelper(_context, true).CreateANewVacancyForSpecificEmployer(_loginUser.OrganisationName, _objectContext.GetHashedAccountId());

            ConfirmationMessage(vacancyReferencePage, "Vacancy submitted to employer");
        }

        [When(@"the Employer rejects the advert")]
        public void WhenTheEmployerRejectsTheAdvert()
        {
            var vacancyReferencePage = GoToVacancyCompletedPage().RejectAdvert().SelectYes();

            ConfirmationMessage(vacancyReferencePage, "You've rejected this job advert");
        }

        [Then(@"the Provider should see the advert with status: '(.*)'")]
        public void ThenTheProviderShouldSeeTheAdvertWithStatus(string expectedStatus)
        {
            _resultPage = _providerStepsHelper.SearchVacancy();

            _resultPage.VerifyAdvertStatus(expectedStatus);
        }

        [When(@"Provider re-submits the advert")]
        public void WhenProviderRe_SubmitsTheAdvert()
        {
            var page = _resultPage.GoToRejectedVacancyCompletedPage();

            AssertMessage("has rejected this vacancy for the following reason", page.GetNotificationBanner());

            var vacancyReferencePage = page.ResubmitVacancyToEmployer();

            ConfirmationMessage(vacancyReferencePage, "Vacancy resubmitted to employer");
        }

        [When(@"the Employer approves the advert")]
        public void WhenTheEmployerApprovesTheAdvert()
        {
            var vacancyReferencePage = GoToVacancyCompletedPage().SubmitAdvert().SelectYes();

            ConfirmationMessage(vacancyReferencePage, "You've submitted this job advert");
        }

        private VacancyCompletedAllSectionsPage GoToVacancyCompletedPage()
        {
            var yourAdvert = _employerStepsHelper.YourAdvert();

            yourAdvert.VerifyAdvertStatus("READY FOR REVIEW");

            return yourAdvert.GoToVacancyCompletedPage();
        }

        private void ConfirmationMessage(VacancyReferencePage vacancyReferencePage, string expected) => AssertMessage(expected, vacancyReferencePage.GetConfirmationMessage());

        private void AssertMessage(string expected, string actual) => StringAssert.Contains(expected, actual);

    }
}
