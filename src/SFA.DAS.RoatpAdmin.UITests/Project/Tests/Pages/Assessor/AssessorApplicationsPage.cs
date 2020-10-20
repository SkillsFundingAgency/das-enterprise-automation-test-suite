using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AssessorApplicationsPage : AssessorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";
        private readonly ScenarioContext _context;

        public By AssignToMeLink => By.XPath($"//td[contains(text(),'{objectContext.GetProviderName()}')]//following-sibling::td//a");

        public AssessorApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationAssessmentOverviewPage AssessorSelectsAssignToMe()
        {
            formCompletionHelper.Click(AssignToMeLink);
            return new ApplicationAssessmentOverviewPage(_context);
        }
        public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMeForMainProvider()
        {
            formCompletionHelper.ClickLinkByText("Moderation");
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
        public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMeForSupportingProvider()
        {
            formCompletionHelper.ClickLinkByText("Moderation");
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
        public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMeForEmployerProvider()
        {
            formCompletionHelper.ClickLinkByText("Moderation");
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
    }
}
