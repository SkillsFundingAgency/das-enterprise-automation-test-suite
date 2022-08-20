using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class ConfirmMyApprenticeshipStepsHelper
    {
        private readonly ScenarioContext _context;
        protected readonly ObjectContext _objectContext;
        protected readonly RetryAssertHelper _assertHelper;
        protected readonly ApprenticeCommitmentsSqlDbHelper _aApprenticeCommitmentsSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        private string expectedApprenticeshipName, expectedApprenticeshipLevel, deliveryModel;
        private DateTime expectedApprenticeshipStartDate;
        private DateTime expectedApprenticeshipEndDate;
        private DateTime expectedJobEndDate;
        private string actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualEsimatedDurationInfo;
        private string actualApprenticeshipEndDate, actualJobEndDate;
        private ApprenticeOverviewPage apprenticeOverviewPage;
        private readonly string[] _tags;

        public ConfirmMyApprenticeshipStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<RetryAssertHelper>();
            _aApprenticeCommitmentsSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
            _tags = context.ScenarioInfo.Tags;
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
            apprenticeOverviewPage = ConfirmYourApprenticeshipDetails(OverviewPageHelper.InComplete);
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

        public ApprenticeOverviewPage ConfirmYourApprenticeshipDetails(string initialStatus)
        {
            AssertSection3Status(initialStatus);

            if (_tags.Contains("portableflexijob"))
                apprenticeOverviewPage = NavigateAndVerifyPortableApprenticeshipDetails().SelectYesAndContinueToOverviewPage();
            else
                apprenticeOverviewPage = NavigateAndVerifyApprenticeshipDetails().SelectYesAndContinueToOverviewPage();

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

        public ConfirmYourPortableApprenticeshipDetailsPage NavigateAndVerifyPortableApprenticeshipDetails()
        {
            var page = new ApprenticeOverviewPage(_context).GoToConfirmYourPortableApprenticeshipDetailsPage();
            VerifyPortableApprenticeshipDataDisplayed(page);
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
        }

        public void VerifyPortableApprenticeshipDataDisplayed(ConfirmYourPortableApprenticeshipDetailsPage confirmYourPortableApprenticeshipDetailsPage)
        {
            PopulateExpectedApprenticeshipDetails();

            deliveryModel = confirmYourPortableApprenticeshipDetailsPage.GetDeliveryModelInfo();
            actualApprenticeshipName = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourPortableApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedStartDateInfo();
            actualApprenticeshipEndDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedEndDateInfo();
            actualJobEndDate = confirmYourPortableApprenticeshipDetailsPage.GetPortableApprenticeshipPlannedJobEndDateInfo();

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

            if (_tags.Contains("portableflexijob"))
            {
                var email = _objectContext.GetApprenticeEmail();
                expectedApprenticeshipEndDate = DateTime.Parse(_aApprenticeCommitmentsSqlDbHelper.GetPlannedEndDateFromRegistration(email));
                expectedJobEndDate = DateTime.Parse(_aApprenticeCommitmentsSqlDbHelper.GetEmploymentEndDateFromRegistration(email));
            }
        }

        private void AssertApprenticeshipDetails()
        {
            if (_tags.Contains("portableflexijob"))
            {
                Assert.AreEqual(deliveryModel, "Portable flexi-job");
                Assert.AreEqual(expectedApprenticeshipEndDate.ToString("MMMM yyyy"), actualApprenticeshipEndDate);
                Assert.AreEqual(expectedJobEndDate.ToString("MMMM yyyy"), actualJobEndDate);
            }
            else
                Assert.IsNotNull(actualEsimatedDurationInfo);

            Assert.AreEqual(GetStringWithoutSpacesAndLeftOfParanthesis(expectedApprenticeshipName), GetStringWithoutSpacesAndLeftOfParanthesis(actualApprenticeshipName));
            Assert.AreEqual(expectedApprenticeshipLevel, actualApprenticeshipLevel);
            Assert.AreEqual(expectedApprenticeshipStartDate.ToString("MMMM yyyy"), actualApprenticeshipStartDate);
        }

        private string GetStringWithoutSpacesAndLeftOfParanthesis(string str) => String.Concat(str.ToLower().Trim().Split('(')[0]).RemoveSpace();
    }
}
