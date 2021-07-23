using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CocSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ApprenticeDataHelper _apprenticeDataHelper;
        private readonly EditedApprenticeDataHelper _editedApprenticeDataHelper;
        private readonly EditedApprenticeCourseDataHelper _editedApprenticeCourseDataHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ASCoCEmployerUser _user;

        private CoCConfirmMyApprenticeDetailsPage coCConfirmMyApprenticeDetailsPage;

        public CocSteps(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _apprenticeDataHelper = context.Get<ApprenticeDataHelper>();
            _editedApprenticeDataHelper = context.Get<EditedApprenticeDataHelper>();
            _editedApprenticeCourseDataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            _user = _context.GetUser<ASCoCEmployerUser>();
        }

        [Given(@"a Course date CoC occurs on an apprenticeship on Employer side")]
        public void GivenACourseDateCoCOccursOnAnApprenticeshipOnEmployerSide()
        {
            SetApprenticeName();

            _employerPortalLoginHelper.Login(_user, true);

            var editAppPage = _employerStepsHelper.EditApprenticeDetailsPagePostApproval(false);

            _editedApprenticeCourseDataHelper.SelectAnyStandardCourse(editAppPage.GetSelectedCourse());

            new ApprenticeCommitmentsEditApprenticePage(_context).EditCourseAndDate().AcceptChangesAndSubmit();

            _providerStepsHelper.ApproveChangesAndSubmit();
        }

        [When(@"the apprentice logs into the Apprentice portal")]
        public void WhenTheApprenticeLogsIntoTheApprenticePortal()
        {
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_BaseUrl());

            coCConfirmMyApprenticeDetailsPage = new SignIntoApprenticeshipPortalPage(_context).CocSignInToApprenticePortal();
        }

        [Then(@"the apprenticeship details section on the overview page is marked as Incomplete")]
        public void ThenTheApprenticeshipDetailsSectionOnTheOverviewPageIsMarkedAsIncomplete()
        {
            var (sectionName, sectionStatus) = coCConfirmMyApprenticeDetailsPage.GetConfirmYourApprenticeshipStatus();

            StringAssert.AreEqualIgnoringCase("Incomplete", sectionStatus, $"Coc status did not match for {sectionName}");
        }

        [Then(@"the apprentice is able to review and confirm apprenticeship details section")]
        public void ThenTheApprenticeIsAbleToReviewAndConfirmApprenticeshipDetailsSection()
        {
            coCConfirmMyApprenticeDetailsPage.ConfirmYourApprenticeshipDetails().SelectYes().ConfirmYourApprenticeshipFromTheTopBanner();
        }

        private void SetApprenticeName()
        {
            var username = _user.CocApprenticeUser.ApprenticeUsername;

            (string firstName, string lastName) = _aComtSqlDbHelper.GetApprenticeName(username);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                Assert.Fail($"{username} not found in the db");

            _apprenticeDataHelper.UpdateCurrentApprenticeName(firstName, lastName);
            _editedApprenticeDataHelper.UpdateCurrentApprenticeName(firstName, lastName);

            _objectContext.UpdateApprenticeEmail(username);
            _objectContext.UpdateApprenticePassword(_user.CocApprenticeUser.ApprenticePassword);

            _objectContext.SetFirstName(firstName);
            _objectContext.SetLastName(lastName);
        }
    }
}