using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TestDataExport;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LimitingStandardsSteps
    {
        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly ProviderBulkUploadStepsHelper _providerBulkUploadStepsHelper;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;

        private readonly CohortReferenceHelper _cohortReferenceHelper;

        private ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage;

        private ProviderReviewChangesPage providerReviewChangesPage;

        private (ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper) apprentice;

        public LimitingStandardsSteps(ScenarioContext context)
        {
            _context = context;

            _objectContext = context.Get<ObjectContext>();

            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);

            _employerStepsHelper = new EmployerStepsHelper(context);

            _providerStepsHelper = new ProviderStepsHelper(context);

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);

            _cohortReferenceHelper = new CohortReferenceHelper(context);

            _providerBulkUploadStepsHelper = new ProviderBulkUploadStepsHelper(context);
        }

        [Given(@"provider does not offer Standard-X")]
        public void GivenProviderDoesNotOfferStandard_X()
        {
            apprentice = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().FirstOrDefault();

            var course = apprentice.apprenticeCourseDataHelper.CourseDetails;

            _objectContext.SetDebugInformation($"Provider deos not offer {course.Course.larsCode} - '{course.Course.title}' course ");
        }

        [Given(@"provider receives a apprentice request that contains Standard-X")]
        public void GivenProviderReceivesAApprenticeRequestThatContainsStandard_X() => EmployerApproveAndSendToProvider();

        [Given(@"employer edits an apprentice with Standard-X post approval")]
        public void GivenEmployerEditsAnApprenticeWithStandard_XPostApproval()
        {
            EmployerApproveAndSendToProvider();

            _providerStepsHelper.Approve();

            var larsCode = _context.Get<RoatpV2SqlDataHelper>().GetCoursesthatProviderDeosNotOffer(_context.GetProviderConfig<ProviderConfig>()?.Ukprn);

            var randomLarsCode = RandomDataGenerator.GetRandomElementFromListOfElements(larsCode);

            _employerStepsHelper.EditApprenticeDetailsPagePostApproval().EditCourse(randomLarsCode).AcceptChangesAndSubmit();
        }

        [When(@"provider opens the cohort")]
        public void WhenProviderOpensTheCohort() => providerReviewChangesPage = _providerStepsHelper.ReviewChanges();

        [Then(@"provider see warning messages in review changes page")]
        public void ThenProviderSeeWarningMessagesInReviewChangesPage() => providerReviewChangesPage.VerifyLimitingStandardRestriction();

        [When(@"provider opens apprentice requests")]
        public void WhenProviderOpensApprenticeRequests() => providerApproveApprenticeDetailsPage = _providerStepsHelper.ViewCurrentCohortDetails();

        [Then(@"provider see warning messages in approve apprentice page")]
        public void ThenProviderSeeWarningMessagesInApproveApprenticePage() => providerApproveApprenticeDetailsPage.VerifyLimitingStandardRestriction();

        [Then(@"provider should not see Standard-X in add apprentice details page")]
        public void ThenProviderShouldNotSeeStandard_XInAddApprenticeDetailsPage() => _providerCommonStepsHelper.ChooseALevyEmployer().ConfirmEmployer().AssertStandardIsNotAvailable();

        [Then(@"provider can not upload file using Standard-X")]
        public void ThenProviderCanNotUploadFileUsingStandard_X()
        {
            var employerUser = _context.GetUser<EmployerWithMultipleAccountsUser>();

            var employerName = string.Concat(employerUser.OrganisationName.AsSpan(0, 3), "%");

            var agreementId = _context.Get<AccountsDbSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();

            apprentice = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().FirstOrDefault();

            var apprenticeList = new List<BulkUploadApprenticeDetails>()
            {
                new BulkUploadApprenticeDetails(apprentice.apprenticeDataHelper, apprentice.apprenticeCourseDataHelper, agreementId)
            };

            _providerBulkUploadStepsHelper.UsingFileUpload().CreateACsvFile(apprenticeList).UploadFile();

            new BulkCsvUploadValidateErrorMsghelper(_context).VerifyErrorMessage("Enter a valid standard code. You have not told us that you deliver this training course. You must assign the course to your account");

        }

        private void EmployerApproveAndSendToProvider()
        {
            _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>());

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }
    }
}
