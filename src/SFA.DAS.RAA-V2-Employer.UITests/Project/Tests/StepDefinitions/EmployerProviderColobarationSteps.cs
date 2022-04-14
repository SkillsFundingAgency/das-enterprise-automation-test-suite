using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using EmployerStepsHelper = SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers.EmployerStepsHelper;
using ProviderStepsHelper = SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers.ProviderStepsHelper;
using SFA.DAS.Login.Service;
using NUnit.Framework;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerProviderColobarationSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private EasAccountUser _loginUser;
        private ProviderVacancySearchResultPage _resultPage;

        public EmployerProviderColobarationSteps(ScenarioContext context)
        {
            _context = context;
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

            _employerPermissionsStepsHelper.SetAgreementId(homePage, _loginUser.OrganisationName);

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
            var vacancyReferencePage = _providerStepsHelper.CreateANewVacancy(_loginUser.OrganisationName, true, false, true, false, true);

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
            var page = _resultPage.GoToVacancyCompletedPage();

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

            yourAdvert.VerifyAdvertStatus("Ready for review");

            return yourAdvert.GoToVacancyCompletedPage();
        }

        private void ConfirmationMessage(VacancyReferencePage vacancyReferencePage, string expected) => AssertMessage(expected, vacancyReferencePage.GetConfirmationMessage());

        private void AssertMessage(string expected, string actual) => StringAssert.Contains(expected, actual);

    }
}
