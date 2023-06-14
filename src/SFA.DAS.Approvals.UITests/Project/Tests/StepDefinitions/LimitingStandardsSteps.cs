using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.TestDataExport;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "limitingstandards")]
    public class LimitingStandardsSteps
    {
        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;

        private readonly CohortReferenceHelper _cohortReferenceHelper;

        private ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage;

        public LimitingStandardsSteps(ScenarioContext context)
        {
            _context = context;

            _objectContext = context.Get<ObjectContext>();

            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);

            _employerStepsHelper = new EmployerStepsHelper(context);

            _providerStepsHelper = new ProviderStepsHelper(context);

            _cohortReferenceHelper = new CohortReferenceHelper(context);

        }

        [Given(@"provider does not offer Standard-X")]
        public void GivenProviderDoesNotOfferStandard_X()
        {
            var listOfApprentices = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>();

            var course = listOfApprentices.FirstOrDefault().Item2.CourseDetails;

            _objectContext.SetDebugInformation($"Provider deos not offer {course.Course.larsCode} - '{course.Course.title}' course ");
        }

        [Given(@"provider receives a apprentice request that contains Standard-X")]
        public void GivenProviderReceivesAApprenticeRequestThatContainsStandard_X()
        {
            _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>());

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        [When(@"provider opens apprentice requests")]
        public void WhenProviderOpensApprenticeRequests() => providerApproveApprenticeDetailsPage = _providerStepsHelper.ViewCurrentCohortDetails();

        [Then(@"provider see warning messages about limiting standards")]
        public void ThenProviderSeeWarningMessagesAboutLimitingStandards() => providerApproveApprenticeDetailsPage.VerifyLimitingStandardRestriction();

        [Then(@"provider should not see Standard-X in add apprentice details page")]
        public void ThenProviderShouldNotSeeStandard_XInAddApprenticeDetailsPage()
        {
            _providerStepsHelper.ChooseALevyEmployer().ConfirmEmployer().AssertStandardIsNotAvailable();
        }

        [Then(@"provider can not upload file using Standard-X")]
        public void ThenProviderCanNotUploadFileUsingStandard_X()
        {
            _providerStepsHelper.UsingFileUpload();

        }

    }
}
