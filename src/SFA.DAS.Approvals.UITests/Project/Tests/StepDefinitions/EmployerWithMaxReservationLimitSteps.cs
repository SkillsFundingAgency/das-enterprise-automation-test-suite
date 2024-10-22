using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerWithMaxReservationLimitSteps
    {
        private readonly ScenarioContext _context;
        private readonly NonLevyUserAtMaxReservationLimit _nonLevyUserAtMaxReservationLimit;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private readonly EmployerCreateCohortStepsHelper _employerCreateCohortStepsHelper;

        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;

        public EmployerWithMaxReservationLimitSteps(ScenarioContext context)
        {
            _context = context;
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _nonLevyUserAtMaxReservationLimit = context.GetUser<NonLevyUserAtMaxReservationLimit>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerCreateCohortStepsHelper = new EmployerCreateCohortStepsHelper(context);
        }

        [Given(@"the Employer logins using an existing NonLevy Account which has reached it max reservations limit")]
        public void TheEmployerAtMaxReservationLimitLogins()
        {
            _employerPortalLoginHelper.Login(_nonLevyUserAtMaxReservationLimit, false);
        }

        [When(@"user tries to create an apprenticeship request \(cohort\)")]
        public void TheUserTriesToCreateAnApprenticeRequestWithCohort()
        {
            _employerCreateCohortStepsHelper.NonLevyEmployerTriesToAddApprentice();
        }

        [Then(@"the Employer is blocked with a shutter page")]
        public void TheEmployerIsBlockedWithAShutterPage()
        {
            _employerCreateCohortStepsHelper.NonLevyEmployerTriesToAddApprenticeButHitsReservationShutterPage();
        }

        [When(@"the Employer tries to add an apprentice to an existing cohort")]
        public void TheEmployerTriesToAddApprenticeToExistingCohort()
        {
            _approveApprenticeDetailsPage = new EmployerStepsHelper(_context).EmployerReviewsTopCohortInReadyToReview();
        }

        [Then(@"the Employer is blocked with a shutter page for existing cohort")]
        public void TheEmployerIsBlockedWithAShutterPageForExistingCohort()
        {
            _approveApprenticeDetailsPage.SelectAddAnotherApprenticeWithMaxReservationLimit();
        }
    }
}
