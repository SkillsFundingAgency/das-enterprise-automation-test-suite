using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
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

        public OverallApprenticeshipConfirmedPage ConfirmAllSectionsAndApprenticeship()
        {
            var apprenticeOverviewPage = ConfirmAllSections().VerifyTopBannerOnOverviewPageBeforeOverallConfirmation();
            AssertSection6Status(OverviewPageHelper.InComplete);
            return apprenticeOverviewPage.ConfirmOverallApprenticeship();
        }

        public ApprenticeOverviewPage ConfirmYourEmployer(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourEmployerPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmYourTrainingProvider(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourTrainingProviderPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmYourApprenticeshipDetails(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourApprenticeshipDetailsPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmAllSections()
        {
            var apprenticeOverviewPage = ConfirmYourEmployer(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmYourTrainingProvider(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmApprenticeshipDetails(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmHowYourApprenticeshipWillBeDelivered(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmRolesAndResponsibilities(OverviewPageHelper.InComplete);
            return VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
        }

        public ApprenticeOverviewPage VerifyCMADSectionStatusOnTheHomePageToBeInComplete(ApprenticeOverviewPage apprenticeOverviewPage)
            => apprenticeOverviewPage.NavigateToHomePageFromTopNavigationLink().VerifyDashboardCMADSectionWhenInCompleteOnHomePage().NavigateToOverviewPageWithCmadLinkOnTheHomePage();

        public ApprenticeOverviewPage ConfirmYourEmployer(string initialStatus)
        {
            AssertSection1Status(initialStatus);
            var apprenticeOverviewPage = ConfirmYourEmployer(new ApprenticeOverviewPage(_context));
            AssertSection1Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmYourTrainingProvider(string initialStatus)
        {
            AssertSection2Status(initialStatus);
            var apprenticeOverviewPage = ConfirmYourTrainingProvider(new ApprenticeOverviewPage(_context));
            AssertSection2Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmApprenticeshipDetails(string initialStatus)
        {
            AssertSection3Status(initialStatus);
            var apprenticeOverviewPage = NavigateAndVerifyApprenticeshipDetails().SelectYesAndContinueToOverviewPage();
            AssertSection3Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmHowYourApprenticeshipWillBeDelivered(string initialStatus)
        {
            AssertSection4Status(initialStatus);
            var apprenticeOverviewPage = new ApprenticeOverviewPage(_context).GoToConfirmHowYourApprenticeshipWillBeDeliveredPage().ContinueToCMADOverviewPage();
            AssertSection4Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmRolesAndResponsibilities(string initialStatus)
        {
            AssertSection5Status(initialStatus);
            var apprenticeOverviewPage = NavigateAndVerifyRolesAndResponsibilities();
            AssertSection5Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmRolesAndResponsibilitiesWithNegativeFlows(string initialStatus)
        {
            AssertSection5Status(initialStatus);
            var apprenticeOverviewPage = VerifyAndConfirmRolesAndResponsibilitiesWithNegativeFlows(NavigateToRolesPage());
            AssertSection5Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ConfirmYourApprenticeshipDetailsPage NavigateAndVerifyApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(_context).GoToConfirmYourApprenticeshipDetailsPage();
            VerifyApprenticeshipDataDisplayed(page);
            return page;
        }

        public ApprenticeOverviewPage AssertSection1Status(string expectedStatus) => AssertSectionStatus(OverviewPageHelper.Section1, expectedStatus);

        public ApprenticeOverviewPage AssertSection2Status(string expectedStatus) => AssertSectionStatus(OverviewPageHelper.Section2, expectedStatus);

        public ApprenticeOverviewPage AssertSection3Status(string expectedStatus) => AssertSectionStatus(OverviewPageHelper.Section3, expectedStatus);

        public ApprenticeOverviewPage AssertSection4Status(string expectedStatus) => AssertSectionStatus(OverviewPageHelper.Section4, expectedStatus);

        public ApprenticeOverviewPage AssertSection5Status(string expectedStatus) => AssertSectionStatus(OverviewPageHelper.Section5, expectedStatus);

        public ApprenticeOverviewPage AssertSection6Status(string expectedStatus) => AssertSection6Status(OverviewPageHelper.Section6, expectedStatus);

        public ApprenticeOverviewPage AssertSectionStatus(string sectionName, string expectedStatus)
        {
            var page = new ApprenticeOverviewPage(_context);
            Assert.AreEqual(expectedStatus, page.GetTheSectionStatus(sectionName));
            return page;
        }

        public ApprenticeOverviewPage AssertSection6Status(string sectionName, string expectedStatus)
        {
            var page = new ApprenticeOverviewPage(_context,false);
            Assert.AreEqual(expectedStatus, page.GetTheSectionStatus(sectionName));
            return page;
        }

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

        public ApprenticeOverviewPage VerifyAndConfirmRolesAndResponsibilities(ConfirmRolesAndResponsibilitiesPage1of3 confirmRolesAndResponsibilitiesPage1of3)
        {
            return confirmRolesAndResponsibilitiesPage1of3
                .ConfirmYourRolesAndContinue()
                .ConfirmEmployerRolesAndContinue()
                .ConfirmTrainingProviderRolesAndContinue();
        }

        public ApprenticeOverviewPage VerifyAndConfirmRolesAndResponsibilitiesWithNegativeFlows(ConfirmRolesAndResponsibilitiesPage1of3 confirmRolesAndResponsibilitiesPage1of3)
        {
            return confirmRolesAndResponsibilitiesPage1of3
                .ConfirmYourRolesWithOutSelectionAndContinue()
                .ConfirmYourRolesAndContinue()
                .ConfirmEmployerRolesWithOutSelectionAndContinue()
                .ConfirmEmployerRolesAndContinue()
                .ConfirmTrainingProviderRolesWithOutSelectionAndContinue()
                .ConfirmTrainingProviderRolesAndContinue();
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(AlreadyConfirmedRolesAndResponsibilitiesPage alreadyConfirmedRolesAndResponsibilitiesPage)
            => alreadyConfirmedRolesAndResponsibilitiesPage.VerifySubSectionHeaders();

        private ApprenticeOverviewPage NavigateAndVerifyRolesAndResponsibilities() => VerifyAndConfirmRolesAndResponsibilities(NavigateToRolesPage());

        private ConfirmRolesAndResponsibilitiesPage1of3 NavigateToRolesPage() => new ApprenticeOverviewPage(_context).GoToConfirmRolesAndResponsibilitiesPage();

        private void PopulateExpectedApprenticeshipDetails()
        {
            expectedApprenticeshipName = _objectContext.GetTrainingName().Split(',')[0];
            expectedApprenticeshipLevel = _objectContext.GetTrainingName().Split(':')[1].Trim()[0].ToString();
            expectedApprenticeshipStartDate = DateTime.Parse(_objectContext.GetTrainingStartDate());
        }

        private void AssertApprenticeshipDetails()
        {
            Assert.AreEqual(GetStringWithoutSpacesAndLeftOfParanthesis(expectedApprenticeshipName), GetStringWithoutSpacesAndLeftOfParanthesis(actualApprenticeshipName));
            Assert.AreEqual(expectedApprenticeshipLevel, actualApprenticeshipLevel);
            Assert.AreEqual(actualApprenticeshipStartDate, expectedApprenticeshipStartDate.ToString("MMMM yyyy"));
            Assert.IsNotNull(actualEsimatedDurationInfo);
        }

        private string GetStringWithoutSpacesAndLeftOfParanthesis(string str) => String.Concat(str.ToLower().Trim().Split('(')[0]).RemoveSpace();
    }
}
