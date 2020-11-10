using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class RoatpApplicationsHomePage : AssessorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";

        private readonly ScenarioContext _context;

        private By Assessor1Link => By.CssSelector("a[href*='assessorNumber=1']");
        private By Assessor2Link => By.CssSelector("a[href*='assessorNumber=2']");
        private By OutcomeStatus => By.CssSelector("[data-label='Outcome']");
        private By UkprnStatus => By.CssSelector("[data-label='UKPRN']");

        public RoatpApplicationsHomePage(ScenarioContext context) : base(context) => _context = context;

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

        public ModerationApplicationAssessmentOverviewPage SelectFromOutcomeTab()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OutcomeTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public RoatpApplicationsHomePage VerifyOutcomeStatus(string expectedStatus)
        {
            return VerifyApplicationStatus(OutcomeStatus, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OutcomeTab)));
        }

        public RoatpApplicationsHomePage VerifyClarificationStatus()
        {
            return VerifyApplicationStatus(UkprnStatus, objectContext.GetUkprn(), () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab)));
        }

        private ApplicationAssessmentOverviewPage AssessorSelectsAssignToMe(By columnIdentifier)
        {
            formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(objectContext.GetUkprn(), columnIdentifier));
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}
