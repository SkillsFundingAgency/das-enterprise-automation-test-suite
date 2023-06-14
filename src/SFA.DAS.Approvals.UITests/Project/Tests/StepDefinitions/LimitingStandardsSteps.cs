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

        public LimitingStandardsSteps(ScenarioContext context)
        {
            _context = context;

            _objectContext = context.Get<ObjectContext>();

            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);

            _employerStepsHelper = new EmployerStepsHelper(context);

            _providerStepsHelper = new ProviderStepsHelper(context);

            _cohortReferenceHelper = new CohortReferenceHelper(context);

        }

        [Given(@"Provider does not offer Standard-X")]
        public void GivenProviderDoesNotOfferStandard_X()
        {
            var listOfApprentices = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>();

            var course = listOfApprentices.FirstOrDefault().Item2.CourseDetails;

            _objectContext.SetDebugInformation($"Provider deos not offer {course.Course.larsCode} - '{course.Course.title}' course ");
        }

        [Given(@"Provider receives a cohort that contains Standard-X")]
        public void GivenProviderReceivesACohortThatContainsStandard_X()
        {
            _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>());

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        [When(@"provider opens the cohort")]
        public void WhenProviderOpensTheCohort()
        {
            _providerStepsHelper.SelectViewCurrentApprenticeDetails();
        }



    }
}
