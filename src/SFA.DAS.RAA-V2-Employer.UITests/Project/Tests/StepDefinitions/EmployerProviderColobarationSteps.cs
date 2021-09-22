using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using EmployerStepsHelper = SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers.EmployerStepsHelper;
using ProviderStepsHelper = SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers.ProviderStepsHelper;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using NUnit.Framework;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerProviderColobarationSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly RAAV2DataHelper _rAAV2DataHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        private readonly ProviderPermissionsConfig _providerPermissionConfig;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private LoginUser _loginUser;
        private ProviderVacancySearchResultPage _resultPage;

        public EmployerProviderColobarationSteps(ScenarioContext context)
        {
            _context = context;
            _rAAV2DataHelper = context.Get<RAAV2DataHelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _providerPermissionConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"the Employer grants permission to the provider to create advert with review option")]
        public void GivenTheEmployerGrantsPermissionToTheProviderToCreateAdvertWithReviewOption()
        {
            _loginUser = _context.GetUser<RAAV2EmployerProviderPermissionUser>();

            var homePage = _employerStepsHelper.GoToHomePage(_loginUser);

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

            ConfirmStatusMessage(_resultPage, expectedStatus);
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

            ConfirmStatusMessage(yourAdvert, "Ready for review");

            return yourAdvert.GoToVacancyCompletedPage();
        }

        private void ConfirmStatusMessage(VacancySearchResultPage page, string expected) => AssertMessage(expected, page.GetYourAdvertStatus());

        private void ConfirmationMessage(VacancyReferencePage vacancyReferencePage, string expected) => AssertMessage(expected, vacancyReferencePage.GetConfirmationMessage());

        private void AssertMessage(string expected, string actual) => StringAssert.Contains(expected, actual);

    }
}
