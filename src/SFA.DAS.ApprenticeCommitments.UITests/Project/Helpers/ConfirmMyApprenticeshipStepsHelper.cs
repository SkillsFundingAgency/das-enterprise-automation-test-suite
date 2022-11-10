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
        protected readonly ApprenticeCommitmentsSqlDbHelper _apprenticeCommitmentsSqlDbHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        protected readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper;
        private string expectedApprenticeshipName, expectedApprenticeshipLevel, actualDeliveryModel;
        //private string expectedDeliveryModel, expectedApprenticeshipName, expectedApprenticeshipLevel;
        private DateTime expectedApprenticeshipStartDate;
        private DateTime expectedApprenticeshipEndDate;
        private DateTime expectedJobEndDate;
        private string actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualEsimatedDurationInfo;
        //private string actualApprenticeshipDeliveryModel, actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualEsimatedDurationInfo;
        private string actualApprenticeshipEndDate, actualJobEndDate;
        private ApprenticeOverviewPage _apprenticeOverviewPage;
        private FullyConfirmedOverviewPage _fullyConfirmedOverviewPage;
        private string email, expectedEmpName, expectedProviderName;

        public ConfirmMyApprenticeshipStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<RetryAssertHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _apprenticeCommitmentsSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
        }

        //public OverallApprenticeshipConfirmedPage ConfirmAllSectionsAndApprenticeship()
        //{
        //    var apprenticeOverviewPage = ConfirmAllSections().VerifyTopBannerOnOverviewPageBeforeOverallConfirmation();
        //    AssertSection6Status(OverviewPageHelper.InComplete);
        //    return apprenticeOverviewPage.ConfirmOverallApprenticeship();
        //}

        public OverallApprenticeshipConfirmedPage ConfirmAllSectionsAndOverallApprenticeship(bool isRegularApp = true)
        {
            var apprenticeOverviewPage = ConfirmAllSections(isRegularApp).VerifyTopBannerOnOverviewPageBeforeOverallConfirmation();
            AssertSection6Status(OverviewPageHelper.InComplete);
            return apprenticeOverviewPage.ConfirmOverallApprenticeship();
        }

        public ApprenticeOverviewPage ConfirmYourEmployer(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourEmployerPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmYourTrainingProvider(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourTrainingProviderPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmYourApprenticeshipDetails(ApprenticeOverviewPage apprenticeOverviewPage) => apprenticeOverviewPage.GoToConfirmYourApprenticeshipDetailsPage().SelectYesAndContinueToOverviewPage();

        public ApprenticeOverviewPage ConfirmAllSections(bool isRegularApp)
        {
            var apprenticeOverviewPage = ConfirmYourEmployer(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            apprenticeOverviewPage = ConfirmYourTrainingProvider(OverviewPageHelper.InComplete);
            VerifyCMADSectionStatusOnTheHomePageToBeInComplete(apprenticeOverviewPage);
            //apprenticeOverviewPage = ConfirmApprenticeshipDetails(OverviewPageHelper.InComplete);
            apprenticeOverviewPage = ConfirmYourApprenticeshipDetails(OverviewPageHelper.InComplete, isRegularApp);
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

        //public ApprenticeOverviewPage ConfirmApprenticeshipDetails(string initialStatus)
        //{
        //    AssertSection3Status(initialStatus);
        //    var apprenticeOverviewPage = NavigateAndVerifyApprenticeshipDetails().SelectYesAndContinueToOverviewPage();
        //    AssertSection3Status(OverviewPageHelper.Complete);
        //    return apprenticeOverviewPage;
        //}

        public ApprenticeOverviewPage ConfirmYourApprenticeshipDetails(string initialStatus, bool isRegularApp = true)
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

        public ConfirmYourPortableApprenticeshipDetailsPage NavigateAndVerifyPortableApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(_context).GoToConfirmYourPortableApprenticeshipDetailsPage();
            VerifyPortableApprenticeshipDataDisplayed(page);
            return page;
        }

        public ConfirmYourFlexiJobApprenticeshipDetailsPage NavigateAndVerifyFlexijobApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(_context).GoToConfirmYourFlexiJobApprenticeshipDetailsPage();
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
            var page = new ApprenticeOverviewPage(_context);
            Assert.AreEqual(expectedStatus, page.GetTheSectionStatus(sectionName));
            return page;
        }

        public ApprenticeOverviewPage AssertSection6Status(string sectionName, string expectedStatus)
        {
            var page = new ApprenticeOverviewPage(_context, false);
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
            AssertActualEsimatedDurationInfo();
        }

        public void VerifyPortableApprenticeshipDataDisplayed(ConfirmYourPortableApprenticeshipDetailsPage confirmYourPortableApprenticeshipDetailsPage)
        {
            PopulateExpectedApprenticeshipDetails();
            PopulateExpectedJobEndDateForPortableApprenticeship();

            actualDeliveryModel = confirmYourPortableApprenticeshipDetailsPage.GetDeliveryModelInfo();
            actualApprenticeshipName = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedStartDateInfo();
            actualApprenticeshipEndDate = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipEndDateInfo();
            actualJobEndDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedJobEndDateInfo();

            AssertApprenticeshipDetails();
            AssertApprenticeshipDetailsForPortableApprenticeship();
        }

        public void VerifyFlexijobApprenticeshipDataDisplayed(ConfirmYourFlexiJobApprenticeshipDetailsPage confirmYourApprenticeshipDetailsPage)
        {
            PopulateExpectedFlexijobApprenticeshipDetails();
            actualDeliveryModel = confirmYourApprenticeshipDetailsPage.GetDeliveryModelInfo();
            actualApprenticeshipName = confirmYourApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourApprenticeshipDetailsPage.GetFlexiJobApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = confirmYourApprenticeshipDetailsPage.GetFlexiJobApprenticeshipEstimatedDurationInfo();
            AssertFlexijobApprenticeshipDetails();
        }

        public void VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(AlreadyConfirmedApprenticeshipDetailsPage alreadyConfirmedApprenticeshipDetailsPage)
        {
            PopulateExpectedApprenticeshipDetails();
            actualApprenticeshipName = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualEsimatedDurationInfo = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipEstimatedDurationInfo();
            AssertApprenticeshipDetails();
            AssertActualEsimatedDurationInfo();
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

        public FullyConfirmedOverviewPage VerifyFullyConfirmedRegularAppOverviewPageDetails()
        {
            NavigateToFullyConfirmedOverviewPageAndValidateRegularAppDetails();
            return _fullyConfirmedOverviewPage;
        }

        public FullyConfirmedOverviewPage VerifyFullyConfirmedPortableAppOverviewPageDetails()
        {
            NavigateToFullyConfirmedOverviewPageAndValidateRegularAppDetails();
            ValidatePortableAppInfoOnFullyConfirmedOverviewPage();
            return _fullyConfirmedOverviewPage;
        }

        private void NavigateToFullyConfirmedOverviewPageAndValidateRegularAppDetails()
        {
            _fullyConfirmedOverviewPage = new ApprenticeHomePage(_context, false).NavigateToFullyConfirmedOverviewPageFromTopNavigationLink();

            (expectedEmpName, expectedProviderName) = _accountsAndCommitmentsSqlHelper.GetEmpAndProvNames(_objectContext.GetApprenticeEmail());

            Assert.AreEqual(expectedEmpName.ToUpper(), _fullyConfirmedOverviewPage.GetEmployer());
            Assert.AreEqual(expectedProviderName.ToUpper(), _fullyConfirmedOverviewPage.GetTrainingProvider());
            Assert.AreEqual(expectedApprenticeshipLevel, _fullyConfirmedOverviewPage.GetApprenticeshipLevelInfo());
            Assert.AreEqual(expectedApprenticeshipStartDate.ToString("MMMM yyyy"), _fullyConfirmedOverviewPage.GetPortableApprenticeshipPlannedStartDateInfo());
            Assert.AreEqual(expectedApprenticeshipEndDate.ToString("MMMM yyyy"), _fullyConfirmedOverviewPage.GetApprenticeshipEndDateInfo());
        }

        private void ValidatePortableAppInfoOnFullyConfirmedOverviewPage()
        {
            Assert.AreEqual(expectedJobEndDate.ToString("MMMM yyyy"), _fullyConfirmedOverviewPage.GetPortableApprenticeshipCurrentJobEndDateInfo());
            Assert.AreEqual("Portable flexi-job", _fullyConfirmedOverviewPage.GetDeliveryModelInfo());
        }

        private ApprenticeOverviewPage NavigateAndVerifyRolesAndResponsibilities() => VerifyAndConfirmRolesAndResponsibilities(NavigateToRolesPage());

        private ConfirmRolesAndResponsibilitiesPage1of3 NavigateToRolesPage() => new ApprenticeOverviewPage(_context).GoToConfirmRolesAndResponsibilitiesPage();

        private void PopulateExpectedApprenticeshipDetails()
        {
            expectedApprenticeshipName = _objectContext.GetTrainingName().Split(',')[0];
            expectedApprenticeshipLevel = _objectContext.GetTrainingName().Split(':')[1].Trim()[0].ToString();
            expectedApprenticeshipStartDate = DateTime.Parse(_objectContext.GetTrainingStartDate());
        }

        private void PopulateExpectedFlexijobApprenticeshipDetails()
        {
            email = _objectContext.GetApprenticeEmail();
            //expectedDeliveryModel = _objectContext.GetDeliveryModel().Split(',')[0];
            expectedApprenticeshipName = _objectContext.GetTrainingName().Split(',')[0];
            expectedApprenticeshipLevel = _objectContext.GetTrainingName().Split(':')[1].Trim()[0].ToString();
            expectedApprenticeshipStartDate = DateTime.Parse(_objectContext.GetTrainingStartDate());
            expectedApprenticeshipEndDate = DateTime.Parse(_apprenticeCommitmentsSqlDbHelper.GetPlannedEndDateFromRegistration(email));
        }

        private void PopulateExpectedJobEndDateForPortableApprenticeship() => expectedJobEndDate = DateTime.Parse(_apprenticeCommitmentsSqlDbHelper.GetEmploymentEndDateFromRegistration(email));

        private void AssertApprenticeshipDetails()
        {
            Assert.AreEqual(GetStringWithoutSpacesAndLeftOfParanthesis(expectedApprenticeshipName), GetStringWithoutSpacesAndLeftOfParanthesis(actualApprenticeshipName));
            Assert.AreEqual(expectedApprenticeshipLevel, actualApprenticeshipLevel);
            //Assert.AreEqual(actualApprenticeshipStartDate, expectedApprenticeshipStartDate.ToString("MMMM yyyy"));
            Assert.AreEqual(expectedApprenticeshipStartDate.ToString("MMMM yyyy"), actualApprenticeshipStartDate);
            Assert.IsNotNull(actualEsimatedDurationInfo);
        }

        private void AssertFlexijobApprenticeshipDetails()
        {
            string expectedDeliveryModel = "Flexi-job Agency";
            Assert.AreEqual(GetStringWithoutSpacesAndLeftOfParanthesis(expectedApprenticeshipName), GetStringWithoutSpacesAndLeftOfParanthesis(actualApprenticeshipName));
            Assert.AreEqual(expectedDeliveryModel, actualDeliveryModel);
            Assert.AreEqual(expectedApprenticeshipLevel, actualApprenticeshipLevel);
            Assert.AreEqual(actualApprenticeshipStartDate, expectedApprenticeshipStartDate.ToString("MMMM yyyy"));
            Assert.IsNotNull(actualEsimatedDurationInfo);
        }

        private void AssertApprenticeshipDetailsForPortableApprenticeship()
        {
            Assert.AreEqual("Portable flexi-job", actualDeliveryModel);
            Assert.AreEqual(expectedApprenticeshipEndDate.ToString("MMMM yyyy"), actualApprenticeshipEndDate);


            Assert.AreEqual(expectedJobEndDate.ToString("MMMM yyyy"), actualJobEndDate);

        }

        private void AssertActualEsimatedDurationInfo() => Assert.IsNotNull(actualEsimatedDurationInfo);

        private string GetStringWithoutSpacesAndLeftOfParanthesis(string str) => String.Concat(str.ToLower().Trim().Split('(')[0]).RemoveSpace();
    }
}
