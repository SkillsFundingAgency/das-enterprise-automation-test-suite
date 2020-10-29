using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AssessorApplicationsPage : AssessorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";

        private readonly ScenarioContext _context;

        public AssessorApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationAssessmentOverviewPage AssessorSelectsAssignToMe()
        {
            ClickProviderName();
            return new ApplicationAssessmentOverviewPage(_context);
        }

        public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMe()
        {
            formCompletionHelper.ClickLinkByText("Moderation");
            ClickProviderName();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        private void ClickProviderName() => formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
    }
}
