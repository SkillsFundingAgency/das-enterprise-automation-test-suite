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
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LimitingStandardsSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        private readonly EmployerStepsHelper _employerStepsHelper = new(context);

        private readonly ProviderStepsHelper _providerStepsHelper = new(context);

        private readonly ProviderBulkUploadStepsHelper _providerBulkUploadStepsHelper = new(context);

        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper = new(context);

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);

        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper = new(context);

        private readonly CohortReferenceHelper _cohortReferenceHelper = new(context);

        private ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage;

        private ProviderReviewChangesPage providerReviewChangesPage;

        private (ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper) apprentice;

        [Given(@"provider does not offer Standard-X")]
        public void GivenProviderDoesNotOfferStandard_X()
        {
            apprentice = context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().FirstOrDefault();

            var course = apprentice.apprenticeCourseDataHelper.CourseDetails;

            _objectContext.SetDebugInformation($"Provider deos not offer {course.Course.larsCode} - '{course.Course.title}' course ");
        }

        [Given(@"provider receives a apprentice request that contains Standard-X")]
        public void GivenProviderReceivesAApprenticeRequestThatContainsStandard_X() => EmployerApproveAndSendToProvider();

        [Given(@"employer edits an apprentice with Standard-X post approval")]
        public void GivenEmployerEditsAnApprenticeWithStandard_XPostApproval()
        {
            EmployerApproveAndSendToProvider();

            _providerApproveStepsHelper.EditAndApprove();

            var larsCode = context.Get<RoatpV2SqlDataHelper>().GetCoursesthatProviderDeosNotOffer(context.GetProviderConfig<ProviderConfig>()?.Ukprn);

            var randomLarsCode = RandomDataGenerator.GetRandomElementFromListOfElements(larsCode);

            _employerStepsHelper.EditApprenticeDetailsPagePostApproval().EditCourse(randomLarsCode).AcceptChangesAndSubmit();
        }

        [When(@"provider opens the cohort")]
        public void WhenProviderOpensTheCohort() => providerReviewChangesPage = _providerStepsHelper.ReviewChanges();

        [Then(@"provider see warning messages in review changes page")]
        public void ThenProviderSeeWarningMessagesInReviewChangesPage() => providerReviewChangesPage.VerifyLimitingStandardRestriction();

        [When(@"provider opens apprentice requests")]
        public void WhenProviderOpensApprenticeRequests() => providerApproveApprenticeDetailsPage = _providerCommonStepsHelper.ViewCurrentCohortDetails();

        [Then(@"provider see warning messages in approve apprentice page")]
        public void ThenProviderSeeWarningMessagesInApproveApprenticePage() => providerApproveApprenticeDetailsPage.VerifyLimitingStandardRestriction();

        [Then(@"provider should not see Standard-X in add apprentice details page")]
        public void ThenProviderShouldNotSeeStandard_XInAddApprenticeDetailsPage() => _providerCommonStepsHelper.ChooseALevyEmployer().ConfirmEmployer().AssertStandardIsNotAvailable();

        [Then(@"provider can not upload file using Standard-X")]
        public void ThenProviderCanNotUploadFileUsingStandard_X()
        {
            var employerUser = context.GetUser<EmployerWithMultipleAccountsUser>();

            var employerName = string.Concat(employerUser.OrganisationName.AsSpan(0, 3), "%");

            var agreementId = context.Get<AccountsDbSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();

            apprentice = context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().FirstOrDefault();

            var apprenticeList = new List<BulkUploadApprenticeDetails>()
            {
                new(apprentice.apprenticeDataHelper, apprentice.apprenticeCourseDataHelper, agreementId)
            };

            _providerBulkUploadStepsHelper.UsingFileUpload().CreateACsvFile(apprenticeList).UploadFile();

            new BulkCsvUploadValidateErrorMsghelper(context).VerifyErrorMessage("Enter a valid standard code. You have not told us that you deliver this training course. You must assign the course to your account");

        }

        private void EmployerApproveAndSendToProvider()
        {
            _employerPortalLoginHelper.Login(context.GetUser<LevyUser>());

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }
    }
}
