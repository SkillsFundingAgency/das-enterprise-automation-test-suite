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
        protected readonly ObjectContext _objectContext;
        protected readonly RetryAssertHelper _assertHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        private string expectedApprenticeshipName, expectedApprenticeshipLevel;
        private DateTime expectedApprenticeshipStartDate;
        private string actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualEsimatedDurationInfo;

        public ConfirmMyApprenticeshipStepsHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<RetryAssertHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
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
