using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class ConfirmMyApprenticeshipStepsHelper
    {
        private readonly ScenarioContext _context;
        protected readonly ObjectContext _objectContext;
        protected readonly RetryAssertHelper _assertHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        private string expectedApprenticeshipName, expectedApprenticeshipLevel;
        private DateTime expectedApprenticeshipStartDate;
        private string actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualEsimatedDurationInfo;

        public ConfirmMyApprenticeshipStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<RetryAssertHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
        }

        public TransactionCompletePage ConfirmAllSectionsAndApprenticeship(ApprenticeOverviewPage apprenticeOverviewPage)
        {
            return ConfirmAllSections(apprenticeOverviewPage).ConfirmYourApprenticeshipFromTheTopBanner();
        }

        public ApprenticeOverviewPage ConfirmAllSections(ApprenticeOverviewPage apprenticeOverviewPage)
        {
            return apprenticeOverviewPage.ConfirmYourEmployer().SelectYes()
                .ConfirmYourTrainingProvider().SelectYes()
                .ConfirmYourApprenticeshipDetails().SelectYes()
                .ConfirmHowYourApprenticeshipWillBeDelivered().ContinueToHomePage()
                .ConfirmRolesAndResponsibilities().ContinueToHomePage();
        }

        public ApprenticeOverviewPage ConfirmAllSections()
        {
            var apprenticeOverviewPage = ConfirmYourEmployer(StatusHelper.InComplete);
            VerifyInCompleteTag(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmYourTrainingProvider(StatusHelper.InComplete);
            VerifyInCompleteTag(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmApprenticeshipDetails(StatusHelper.InComplete);
            VerifyInCompleteTag(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmHowYourApprenticeshipWillBeDelivered(StatusHelper.InComplete);
            VerifyInCompleteTag(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmRolesAndResponsibilities(StatusHelper.InComplete);
            return VerifyInCompleteTag(apprenticeOverviewPage);
        }

        public ApprenticeOverviewPage VerifyInCompleteTag(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.NavigateToHomePageFromTopNavigationLink().VerifyInCompleteTag().NavigateToOverviewPageFromLinkOnTheHomePage();

        public ApprenticeOverviewPage ConfirmYourEmployer(string initialStatus)
        {
            AssertSection1Status(initialStatus);

            var apprenticeOverviewPage = new ApprenticeOverviewPage(_context).ConfirmYourEmployer().SelectYes();

            AssertSection1Status(StatusHelper.Complete);

            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmYourTrainingProvider(string initialStatus)
        {

            AssertSection2Status(initialStatus);

            var apprenticeOverviewPage = new ApprenticeOverviewPage(_context).ConfirmYourTrainingProvider().SelectYes();

            AssertSection2Status(StatusHelper.Complete);

            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmApprenticeshipDetails(string initialStatus)
        {
            AssertSection3Status(initialStatus);

            var apprenticeOverviewPage = NavigateAndVerifyApprenticeshipDetails().SelectYes();

            AssertSection3Status(StatusHelper.Complete);

            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmHowYourApprenticeshipWillBeDelivered(string initialStatus)
        {
            AssertSection4Status(initialStatus);

            var apprenticeOverviewPage = NavigateToConfirmHowYourApprenticeshipWillBeDelivered().ContinueToHomePage();

            AssertSection4Status(StatusHelper.Complete);

            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmRolesAndResponsibilities(string initialStatus)
        {
            AssertSection5Status(initialStatus);

            var apprenticeOverviewPage = NavigateAndVerifyRolesAndResponsibilities().ContinueToHomePage();

            AssertSection5Status(StatusHelper.Complete);

            return apprenticeOverviewPage;
        }

        public ConfirmYourApprenticeshipDetailsPage NavigateAndVerifyApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(_context).ConfirmYourApprenticeshipDetails();

            VerifyApprenticeshipDataDisplayed(page);

            return page;
        }

        private ConfirmHowYourApprenticeshipWillBeDeliveredPage NavigateToConfirmHowYourApprenticeshipWillBeDelivered() =>
            new ApprenticeOverviewPage(_context).ConfirmHowYourApprenticeshipWillBeDelivered();

        private ConfirmRolesAndResponsibilitiesPage NavigateAndVerifyRolesAndResponsibilities()
        {
            var page = new ApprenticeOverviewPage(_context).ConfirmRolesAndResponsibilities();

            return VerifyRolesAndResponsibilitiesPage(page);
        }

        public void AssertSection1Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section1, expectedStatus);

        public void AssertSection2Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section2, expectedStatus);

        public void AssertSection3Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section3, expectedStatus);

        public void AssertSection4Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section4, expectedStatus);

        public void AssertSection5Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section5, expectedStatus);

        public void AssertSectionStatus(string sectionName, string expectedStatus) =>
            Assert.AreEqual(expectedStatus, new ApprenticeOverviewPage(_context).GetTheSectionStatus(sectionName));

        public void VerifyApprenticeshipDataDisplayed(ConfirmYourApprenticeshipDetailsPage confirmYourApprenticeshipDetailsPage)
        {
            PopulateExpectedApprenticeshipDetails();
            actualApprenticeshipName = confirmYourApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = confirmYourApprenticeshipDetailsPage.GetApprenticeshipEstimatedDurationInfo();
            AssertApprenticeshipDetails();
        }

        public void VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(AlreadyConfirmedApprenticeshipDetailsPage alreadyConfirmedApprenticeshipDetailsPage)
        {
            PopulateExpectedApprenticeshipDetails();
            actualApprenticeshipName = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipEstimatedDurationInfo();
            AssertApprenticeshipDetails();
        }

        public ConfirmRolesAndResponsibilitiesPage VerifyRolesAndResponsibilitiesPage(ConfirmRolesAndResponsibilitiesPage confirmRolesAndResponsibilitiesPage)
        {
            return confirmRolesAndResponsibilitiesPage.VerifyRolesYourResponsibilitiesTab()
                .VerifyRolesYourEmployerTab()
                .VerifyRolesYourTrainingProviderTab();
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(AlreadyConfirmedRolesAndResponsibilitiesPage confirmRolesAndResponsibilitiesPage)
        {
            return confirmRolesAndResponsibilitiesPage.VerifyRolesYourResponsibilitiesTab()
                .VerifyRolesYourEmployerTab()
                .VerifyRolesYourTrainingProviderTab();
        }

        private void PopulateExpectedApprenticeshipDetails()
        {
            expectedApprenticeshipName = _objectContext.GetTrainingName().Split(',')[0];
            expectedApprenticeshipLevel = _objectContext.GetTrainingName().Split(':')[1].Trim()[0].ToString();
            expectedApprenticeshipStartDate = DateTime.Parse(_objectContext.GetTrainingStartDate());
        }

        private void AssertApprenticeshipDetails()
        {
            Assert.AreEqual(expectedApprenticeshipName.ToLower(), actualApprenticeshipName.ToLower());
            Assert.AreEqual(expectedApprenticeshipLevel, actualApprenticeshipLevel);
            Assert.AreEqual(actualApprenticeshipStartDate, expectedApprenticeshipStartDate.ToString("MMMM yyyy"));
            Assert.IsNotNull(actualEsimatedDurationInfo);
        }
    }
}
