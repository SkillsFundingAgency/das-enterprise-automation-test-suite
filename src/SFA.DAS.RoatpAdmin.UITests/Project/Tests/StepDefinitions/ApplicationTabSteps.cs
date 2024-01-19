using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApplicationTabSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private RoatpAssessorApplicationsHomePage _roatpApplicationsHomePage;

        [Then(@"the Outcome tab is updated as (PASS|FAIL)")]
        public void ThenTheOutcomeTabIsUpdated(string expectedStatus) => _roatpApplicationsHomePage = new RoatpAssessorApplicationsHomePage(context).VerifyOutcomeStatus(expectedStatus);

        [Then(@"the Clarification tab is updated")]
        public void ThenTheClarificationTabIsUpdated() => _roatpApplicationsHomePage = new RoatpAssessorApplicationsHomePage(context).VerifyClarificationStatus();

        [Then(@"verify subsections outcome passed by Clarification assessor are updated as PASS")]
        public void ThenVerifySubsectionsOutcomePassedByClarificationAssessorAreUpdatedAsPASS()
        {
            (var page, var route) = GetApplicationRoute();

            ModeratorEndtoEndStepsHelper.VerifySubSectionsAsPass(page, route);
        }

        [Then(@"verify subsections outcome failed by Clarification assessor are updated as FAIL")]
        public void ThenVerifySubsectionsOutcomeFailedByClarificationAssessorAreUpdatedAsFAIL()
        {
            (var page, var _) = GetApplicationRoute();

            ModeratorEndtoEndStepsHelper.VerifySubSectionsAsFail(page);
        }

        private (ModerationApplicationAssessmentOverviewPage page, ApplicationRoute route) GetApplicationRoute() => (_roatpApplicationsHomePage.SelectFromOutcomeTab(), _objectContext.GetApplicationRoute());

    }
}
