using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class ConfirmMyApprenticeshipStepsHelper(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly ApprenticeCommitmentsSqlDbHelper _apprenticeCommitmentsSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
        private readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
        private string actualDeliveryModel;
        private string actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualEsimatedDurationInfo;
        private string actualApprenticeshipEndDate, actualJobEndDate;
        private ApprenticeOverviewPage _apprenticeOverviewPage;
        private FullyConfirmedOverviewPage _fullyConfirmedOverviewPage;

        public OverallApprenticeshipConfirmedPage ConfirmAllSectionsAndOverallApprenticeship(bool isRegularApp = true)
        {
            var apprenticeOverviewPage = ConfirmAllSections(isRegularApp).VerifyTopBannerOnOverviewPageBeforeOverallConfirmation();
            AssertSection6Status(OverviewPageHelper.InComplete);
            return apprenticeOverviewPage.ConfirmOverallApprenticeship();
        }

        public static ApprenticeOverviewPage ConfirmYourEmployer(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourEmployerPage().SelectYesAndContinueToOverviewPage();

        public static ApprenticeOverviewPage ConfirmYourTrainingProvider(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourTrainingProviderPage().SelectYesAndContinueToOverviewPage();

        public static ApprenticeOverviewPage ConfirmYourApprenticeshipDetails(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourApprenticeshipDetailsPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmAllSections(bool isRegularApp)
        {
            var apprenticeOverviewPage = ConfirmYourEmployer(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmYourTrainingProvider(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmYourApprenticeshipDetails(OverviewPageHelper.InComplete, isRegularApp);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmHowYourApprenticeshipWillBeDelivered(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmRolesAndResponsibilities(OverviewPageHelper.InComplete);
            return VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
        }

        public static ApprenticeOverviewPage VerifyCMADSectionStatusOnTheHomePageToBeInComplete(ApprenticeOverviewPage apprenticeOverviewPage)
            => apprenticeOverviewPage.NavigateToHomePageFromTopNavigationLink().VerifyDashboardCMADSectionWhenInCompleteOnHomePage().NavigateToOverviewPageWithCmadLinkOnTheHomePage();

        public ApprenticeOverviewPage ConfirmYourEmployer(string initialStatus)
        {
            AssertSection1Status(initialStatus);
            var apprenticeOverviewPage = ConfirmYourEmployer(new ApprenticeOverviewPage(context));
            AssertSection1Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmYourTrainingProvider(string initialStatus)
        {
            AssertSection2Status(initialStatus);
            var apprenticeOverviewPage = ConfirmYourTrainingProvider(new ApprenticeOverviewPage(context));
            AssertSection2Status(OverviewPageHelper.Complete);
            return apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmYourApprenticeshipDetails(string initialStatus, bool isRegularApp)
        {
            AssertSection3Status(initialStatus);

            if (isRegularApp)
                _apprenticeOverviewPage = NavigateAndVerifyApprenticeshipDetails().SelectYesAndContinueToOverviewPage();
            else //Portable flexi-job apprenticeship
                _apprenticeOverviewPage = NavigateAndVerifyPortableApprenticeshipDetails().SelectYesAndContinueToOverviewPage();

            AssertSection3Status(OverviewPageHelper.Complete);
            return _apprenticeOverviewPage;
        }

        public ApprenticeOverviewPage ConfirmHowYourApprenticeshipWillBeDelivered(string initialStatus)
        {
            AssertSection4Status(initialStatus);
            var apprenticeOverviewPage = new ApprenticeOverviewPage(context).GoToConfirmHowYourApprenticeshipWillBeDeliveredPage().ContinueToCMADOverviewPage();
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
            var page = new ApprenticeOverviewPage(context).GoToConfirmYourApprenticeshipDetailsPage();
            VerifyApprenticeshipDataDisplayed(page);
            return page;
        }

        public ConfirmYourPortableApprenticeshipDetailsPage NavigateAndVerifyPortableApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(context).GoToConfirmYourPortableApprenticeshipDetailsPage();
            VerifyPortableApprenticeshipDataDisplayed(page);
            return page;
        }

        public ConfirmYourFlexiJobApprenticeshipDetailsPage NavigateAndVerifyFlexijobApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(context).GoToConfirmYourFlexiJobApprenticeshipDetailsPage();
            VerifyFlexijobApprenticeshipDataDisplayed(page);
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
            var page = new ApprenticeOverviewPage(context);
            Assert.AreEqual(expectedStatus, page.GetTheSectionStatus(sectionName));
            return page;
        }

        public ApprenticeOverviewPage AssertSection6Status(string sectionName, string expectedStatus)
        {
            var page = new ApprenticeOverviewPage(context, false);
            Assert.AreEqual(expectedStatus, page.GetTheSectionStatus(sectionName));
            return page;
        }

        public void VerifyApprenticeshipDataDisplayed(ConfirmYourApprenticeshipDetailsPage confirmYourApprenticeshipDetailsPage)
        {
            actualApprenticeshipName = confirmYourApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = confirmYourApprenticeshipDetailsPage.GetApprenticeshipEstimatedDurationInfo();
            AssertApprenticeshipDetails();
            AssertActualEsimatedDurationInfo();
        }

        public void VerifyPortableApprenticeshipDataDisplayed(ConfirmYourPortableApprenticeshipDetailsPage confirmYourPortableApprenticeshipDetailsPage)
        {
            actualDeliveryModel = confirmYourPortableApprenticeshipDetailsPage.GetDeliveryModelInfo();
            actualApprenticeshipName = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedStartDateInfo();
            actualApprenticeshipEndDate = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipEndDateInfo();
            actualJobEndDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedJobEndDateInfo();

            AssertApprenticeshipDetailsForPortableApprenticeship();
        }

        public void VerifyFlexijobApprenticeshipDataDisplayed(ConfirmYourFlexiJobApprenticeshipDetailsPage confirmYourApprenticeshipDetailsPage)
        {
            actualDeliveryModel = confirmYourApprenticeshipDetailsPage.GetDeliveryModelInfo();
            actualApprenticeshipName = confirmYourApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourApprenticeshipDetailsPage.GetFlexiJobApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = confirmYourApprenticeshipDetailsPage.GetFlexiJobApprenticeshipEstimatedDurationInfo();

            AssertFlexijobApprenticeshipDetails();
        }

        public void VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(AlreadyConfirmedApprenticeshipDetailsPage alreadyConfirmedApprenticeshipDetailsPage)
        {
            actualApprenticeshipName = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipEstimatedDurationInfo();
            AssertApprenticeshipDetails();
            AssertActualEsimatedDurationInfo();
        }

        public static ApprenticeOverviewPage VerifyAndConfirmRolesAndResponsibilities(ConfirmRolesAndResponsibilitiesPage1of3 confirmRolesAndResponsibilitiesPage1of3)
        {
            return confirmRolesAndResponsibilitiesPage1of3
                .ConfirmYourRolesAndContinue()
                .ConfirmEmployerRolesAndContinue()
                .ConfirmTrainingProviderRolesAndContinue();
        }

        public static ApprenticeOverviewPage VerifyAndConfirmRolesAndResponsibilitiesWithNegativeFlows(ConfirmRolesAndResponsibilitiesPage1of3 confirmRolesAndResponsibilitiesPage1of3)
        {
            return confirmRolesAndResponsibilitiesPage1of3
                .ConfirmYourRolesWithOutSelectionAndContinue()
                .ConfirmYourRolesAndContinue()
                .ConfirmEmployerRolesWithOutSelectionAndContinue()
                .ConfirmEmployerRolesAndContinue()
                .ConfirmTrainingProviderRolesWithOutSelectionAndContinue()
                .ConfirmTrainingProviderRolesAndContinue();
        }

        public static AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(AlreadyConfirmedRolesAndResponsibilitiesPage alreadyConfirmedRolesAndResponsibilitiesPage)
            => alreadyConfirmedRolesAndResponsibilitiesPage.VerifySubSectionHeaders();

        public FullyConfirmedOverviewPage VerifyFullyConfirmedAppOverviewPageDetails(bool isRegularApp)
        {
            NavigateToFullyConfirmedOverviewPageAndValidateRegularAppDetails();

            if (!isRegularApp) ValidatePortableAppInfoOnFullyConfirmedOverviewPage();

            return _fullyConfirmedOverviewPage;
        }

        private void NavigateToFullyConfirmedOverviewPageAndValidateRegularAppDetails()
        {
            _fullyConfirmedOverviewPage = new ApprenticeHomePage(context, false).NavigateToFullyConfirmedOverviewPageFromTopNavigationLink();

            (string expectedEmpName, string expectedProviderName) = _accountsAndCommitmentsSqlHelper.GetEmpAndProvNames(_objectContext.GetApprenticeEmail());

            Assert.AreEqual(expectedEmpName.ToUpper(), _fullyConfirmedOverviewPage.GetEmployer());
            Assert.AreEqual(expectedProviderName.ToUpper(), _fullyConfirmedOverviewPage.GetTrainingProvider());
            Assert.AreEqual(GetApprenticeshipLevel(), _fullyConfirmedOverviewPage.GetApprenticeshipLevelInfo());
            Assert.AreEqual(GetApprenticeshipStartDate().ToString("MMMM yyyy"), _fullyConfirmedOverviewPage.GetPortableApprenticeshipPlannedStartDateInfo());
        }

        private void ValidatePortableAppInfoOnFullyConfirmedOverviewPage()
        {
            Assert.AreEqual(GetExpectedJobEndDate().ToString("MMMM yyyy"), _fullyConfirmedOverviewPage.GetPortableApprenticeshipCurrentJobEndDateInfo());
            Assert.AreEqual("Portable flexi-job", _fullyConfirmedOverviewPage.GetDeliveryModelInfo());
        }

        private ApprenticeOverviewPage NavigateAndVerifyRolesAndResponsibilities() => VerifyAndConfirmRolesAndResponsibilities(NavigateToRolesPage());

        private ConfirmRolesAndResponsibilitiesPage1of3 NavigateToRolesPage() => new ApprenticeOverviewPage(context).GoToConfirmRolesAndResponsibilitiesPage();

        private string GetApprenticeEmail() => _objectContext.GetApprenticeEmail();

        private string GetApprenticeshipLevel() => _objectContext.GetTrainingLevel().Trim()[0].ToString();

        private DateTime GetApprenticeshipStartDate() => DateTime.Parse(_objectContext.GetTrainingStartDate());

        private DateTime GetExpectedJobEndDate() => DateTime.Parse(_apprenticeCommitmentsSqlDbHelper.GetEmploymentEndDateFromRegistration(GetApprenticeEmail()));

        private void AssertApprenticeshipDetails()
        {
            Assert.True(_objectContext.GetExpectedTrainingTitles().Any(x => actualApprenticeshipName.Contains(x)));
            Assert.AreEqual(GetApprenticeshipLevel(), actualApprenticeshipLevel);
            Assert.AreEqual(GetApprenticeshipStartDate().ToString("MMMM yyyy"), actualApprenticeshipStartDate);
        }

        private void AssertFlexijobApprenticeshipDetails()
        {
            Assert.AreEqual("Flexi-job Agency", actualDeliveryModel);

            AssertApprenticeshipDetails();
        }

        private void AssertApprenticeshipDetailsForPortableApprenticeship()
        {
            AssertApprenticeshipDetails();

            Assert.AreEqual("Portable flexi-job", actualDeliveryModel);
            Assert.AreEqual(DateTime.Parse(_apprenticeCommitmentsSqlDbHelper.GetPlannedEndDateFromRegistration(GetApprenticeEmail())).ToString("MMMM yyyy"), actualApprenticeshipEndDate);
            Assert.AreEqual(GetExpectedJobEndDate().ToString("MMMM yyyy"), actualJobEndDate);
        }

        private void AssertActualEsimatedDurationInfo() => Assert.IsNotNull(actualEsimatedDurationInfo);
    }
}
