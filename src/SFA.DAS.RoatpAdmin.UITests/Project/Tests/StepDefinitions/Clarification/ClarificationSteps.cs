using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Clarification
{
    [Binding]
    public class ClarificationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ClarificationEndtoEndStepsHelper _clarificationEndtoEndStepsHelper;
        private ApplicationRoute _applicationRoute;
        private ModerationApplicationAssessmentOverviewPage _moderationApplicationAssessmentOverviewPage;

        public ClarificationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _clarificationEndtoEndStepsHelper = new ClarificationEndtoEndStepsHelper();
        }

        [When(@"selects the (Main Provider Route|Supporting Provider Route|Employer Provider Route) application from Clarification Tab")]
        public void WhenSelectsTheEmployerProviderRouteApplicationFromClarificationTab(ApplicationRoute applicationroute)
        {
            _objectContext.SetClarificationJourney();

            _objectContext.SetApplicationRoute(applicationroute);

            _applicationRoute = applicationroute;

            _moderationApplicationAssessmentOverviewPage = new StaffDashboardPage(_context).AccessAssessorAndModerationApplications().ClarificationSelectsAssignToMe();
        }

        [Then(@"the Clarification assessor assesses all the sections of the application as PASS")]
        public void ThenTheClarificationAssessorAssessesAllTheSectionsOfTheApplicationAsPASS()
        {
            _moderationApplicationAssessmentOverviewPage = _clarificationEndtoEndStepsHelper.CompleteAllSectionsWithPass(_moderationApplicationAssessmentOverviewPage, _applicationRoute);
        }

        [Then(@"the Clarification assessor FAILS few sections")]
        public void ThenTheClarificationAssessorAssessesFAILSFewSections()
        {
            _moderationApplicationAssessmentOverviewPage = _clarificationEndtoEndStepsHelper.CompleteSomeSectionsWithFail(_moderationApplicationAssessmentOverviewPage, _applicationRoute);
        }

        [Then(@"the Clarification assessor assesses the outcome as PASS")]
        public void ThenTheClarificationAssessorAssessesTheOutcomeAsPASS()
        {
            _clarificationEndtoEndStepsHelper.CompleteClarificationOutcomeSectionAsPass(_moderationApplicationAssessmentOverviewPage);
        }

        [Then(@"the Clarification assessor assesses the outcome as FAIL")]
        public void ThenTheClarificationAssessorAssessesTheOutcomeAsFAIL()
        {
            _clarificationEndtoEndStepsHelper.CompleteClarificationOutcomeSectionAsFail(_moderationApplicationAssessmentOverviewPage);
        }
    }
}
