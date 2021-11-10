using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
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
        private ApprenticeOverviewPage _apprenticeOverviewPage;

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
            var apprenticeEmail = SetApprenticeDetails();
            _employerPortalLoginHelper.Login(_user, true);

            var appDetailPage = _employerStepsHelper.ViewCurrentApprenticeDetails(false);
            if (!(appDetailPage.CanEditApprenticeDetails())) appDetailPage = appDetailPage.ClickViewChangesLink().UndoChanges();

            var editAppPage = appDetailPage.ClickEditApprenticeDetailsLink();
            _editedApprenticeCourseDataHelper.SelectAnyStandardCourse(editAppPage.GetSelectedCourse());

            new ApprenticeCommitmentsEditApprenticePage(_context).EditCourseAndDate().AcceptChangesAndSubmit();
            _providerStepsHelper.ApproveChangesAndSubmit();
            _aComtSqlDbHelper.ConfirmCoCEventHasTriggered(apprenticeEmail, _context.ScenarioInfo.Title);
        }

        [When(@"the apprentice logs into the Apprentice portal")]
        public void WhenTheApprenticeLogsIntoTheApprenticePortal()
        {
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_BaseUrl());
            _apprenticeOverviewPage = new SignIntoMyApprenticeshipPage(_context).CocSignInToApprenticePortal();
        }

        [Then(@"only the employer and apprenticeship detail sections should be marked as Incomplete")]
        public void ThenOnlyTheEmployerAndApprenticeshipDetailsSectionShouldBeMarkedAsIncomplete()
        {
            AssertSectionStatus(SectionStatus.Incomplete, SectionStatus.Complete, SectionStatus.Incomplete, SectionStatus.Complete, SectionStatus.Complete);
            _apprenticeOverviewPage = _apprenticeOverviewPage.VerifyEmployerAndApprenticehsipCoCNotification();
        }

        [Then(@"only the apprenticeship detail section is marked as Incomplete")]
        public void ThenOnlyTheApprenticeshipDetailsSectionIsMarkedAsIncomplete()
        {
            AssertSectionStatus(SectionStatus.Complete, SectionStatus.Complete, SectionStatus.Incomplete, SectionStatus.Complete, SectionStatus.Complete);
            _apprenticeOverviewPage = _apprenticeOverviewPage.VerifyApprenticeshipOnlyCoCNotification();
        }

        [Then(@"the apprentice is able to review and confirm employer and apprenticeship details section")]
        public void ThenTheApprenticeIsAbleToReviewAndConfirmEmployerAndApprenticeshipDetailsSection()
        {
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourEmployer(_apprenticeOverviewPage);
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourApprenticeshipDetails(_apprenticeOverviewPage);
            VerifyCocAndConfirmApprenticeship();
        }

        [Then(@"the apprentice is able to review and confirm apprenticeship details section")]
        public void ThenTheApprenticeIsAbleToReviewAndConfirmApprenticeshipDetailsSection()
        {
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourApprenticeshipDetails(_apprenticeOverviewPage);
            VerifyCocAndConfirmApprenticeship();
        }

        private void AssertSectionStatus(string exsection1Status, string exsection2Status, string exsection3Status, string exsection4Status, string exsection5Status)
        {
            var (sectionName1, section1Status) = _apprenticeOverviewPage.GetConfirmYourEmployerStatus();
            var (sectionName2, section2Status) = _apprenticeOverviewPage.GetConfirmYourTrainingProviderStatus();
            var (sectionName3, section3Status) = _apprenticeOverviewPage.GetConfirmYourApprenticeshipStatus();
            var (sectionName4, section4Status) = _apprenticeOverviewPage.GetConfirmYourApprenticeshipDeliveryStatus();
            var (sectionName5, section5Status) = _apprenticeOverviewPage.GetConfirmYourRolesAndResponsibilityStatus();

            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(exsection1Status, section1Status, $"Coc status did not match for {sectionName1}");
                StringAssert.AreEqualIgnoringCase(exsection2Status, section2Status, $"Coc status did not match for {sectionName2}");
                StringAssert.AreEqualIgnoringCase(exsection3Status, section3Status, $"Coc status did not match for {sectionName3}");
                StringAssert.AreEqualIgnoringCase(exsection4Status, section4Status, $"Coc status did not match for {sectionName4}");
                StringAssert.AreEqualIgnoringCase(exsection5Status, section5Status, $"Coc status did not match for {sectionName5}");
            });
        }

        private string SetApprenticeDetails()
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

            _aComtSqlDbHelper.ConfirmApprenticeship(username);

            return username;
        }

        private void VerifyCocAndConfirmApprenticeship()
        {
            _apprenticeOverviewPage = _apprenticeOverviewPage.VerifyCoCNotificationIsNotDisplayed();
            _apprenticeOverviewPage.ConfirmYourApprenticeshipFromTheTopBanner();
        }
    }
}