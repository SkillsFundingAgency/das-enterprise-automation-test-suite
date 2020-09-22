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

        public By AssignToMeLinkForMainProvider => By.XPath("//td[contains(text(),'7TAO ENGINEERING UK LIMITED')]//following-sibling::td//a");
        public By AssignToMeLinkForSupportingProvider => By.XPath("//td[contains(text(),'ARTHUR MUREVERWI')]//following-sibling::td//a");
        public By AssignToMeLinkForEmployerProvider => By.XPath("//td[contains(text(),'SHOCKOUT ACADEMY')]//following-sibling::td//a");

        public AssessorApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationAssessmentOverviewPage AssessorSelectsAssignToMeForMainProvider()
        {
            formCompletionHelper.Click(AssignToMeLinkForMainProvider);
            return new ApplicationAssessmentOverviewPage(_context);
        }

        public ApplicationAssessmentOverviewPage AssessorSelectsAssignToMeForSupportingProvider()
        {
            formCompletionHelper.Click(AssignToMeLinkForSupportingProvider);
            return new ApplicationAssessmentOverviewPage(_context);
        }

        public ApplicationAssessmentOverviewPage AssessorSelectsAssignToMeForEmployerProvider()
        {
            formCompletionHelper.Click(AssignToMeLinkForEmployerProvider);
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
