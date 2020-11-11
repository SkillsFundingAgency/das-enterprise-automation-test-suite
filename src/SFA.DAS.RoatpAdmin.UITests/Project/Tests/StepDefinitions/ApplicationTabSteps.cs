using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApplicationTabSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ModeratorEndtoEndStepsHelper _moderatorEndtoEndStepsHelper;
        private RoatpApplicationsHomePage _roatpApplicationsHomePage;

        public ApplicationTabSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _moderatorEndtoEndStepsHelper = new ModeratorEndtoEndStepsHelper();
        }

        [Then(@"the Outcome tab is updated as (PASS|FAIL)")]
        public void ThenTheOutcomeTabIsUpdated(string expectedStatus) => _roatpApplicationsHomePage = new RoatpApplicationsHomePage(_context).VerifyOutcomeStatus(expectedStatus);

        [Then(@"the Clarification tab is updated")]
        public void ThenTheClarificationTabIsUpdated() => _roatpApplicationsHomePage = new RoatpApplicationsHomePage(_context).VerifyClarificationStatus();

        [Then(@"the subsections outcome are updated as PASS")]
        public void ThenTheSubsectionsOutcomeAreUpdatedAsPASS()
        {
            (var page, var route) = GetApplicationRoute();

            _moderatorEndtoEndStepsHelper.VerifySubSectionsAsPass(page, route);
        }

        [Then(@"the subsections outcome are updated as FAIL")]
        public void ThenTheSubsectionsOutcomeAreUpdatedAsFAIL()
        {
            (var page, var route) = GetApplicationRoute();

            _moderatorEndtoEndStepsHelper.VerifySubSectionsAsFail(page, route);
        }

        private (ModerationApplicationAssessmentOverviewPage page, ApplicationRoute route) GetApplicationRoute() => (_roatpApplicationsHomePage.SelectFromOutcomeTab(), _objectContext.GetApplicationRoute());

    }
}
