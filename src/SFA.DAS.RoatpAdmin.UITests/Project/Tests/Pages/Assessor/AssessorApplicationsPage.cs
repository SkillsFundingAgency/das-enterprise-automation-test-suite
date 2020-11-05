using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AssessorApplicationsPage : AssessorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";

        private readonly ScenarioContext _context;

        private By Assessor1Link => By.CssSelector("a[href*='assessorNumber=1']");
        private By Assessor2Link => By.CssSelector("a[href*='assessorNumber=2']");

        public AssessorApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationAssessmentOverviewPage Assessor1SelectsAssignToMe() => AssessorSelectsAssignToMe(Assessor1Link);

        public ApplicationAssessmentOverviewPage Assessor2SelectsAssignToMe() => AssessorSelectsAssignToMe(Assessor2Link);

        public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMe()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ModerationTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public ClarificationApplicationAssessmentOverviewPage ClarificationSelectsAssignToMe()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ClarificationApplicationAssessmentOverviewPage(_context);
        }

        private ApplicationAssessmentOverviewPage AssessorSelectsAssignToMe(By columnIdentifier)
        {
            formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(objectContext.GetUkprn(), columnIdentifier));
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}
