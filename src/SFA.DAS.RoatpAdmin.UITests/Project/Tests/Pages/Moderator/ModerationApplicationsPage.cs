using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ClarificationApplicationsPage
    {

    }


    public class ModerationApplicationsPage : ModeratorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";
        private readonly ScenarioContext _context;

        private By OutcomeStatus => By.CssSelector("[data-label='Outcome']");

        private By UkprnStatus => By.CssSelector("[data-label='UKPRN']");

        public ModerationApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ModerationApplicationsPage VerifyOutcomeStatus(string expectedStatus)
        {
            VerifyApplicationStatus(OutcomeStatus, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OutcomeTab)));

            return new ModerationApplicationsPage(_context);
        }

        public ModerationApplicationsPage VerifyClarificationStatus()
        {
            VerifyApplicationStatus(UkprnStatus, objectContext.GetUkprn(), () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab)));

            return new ModerationApplicationsPage(_context);
        }
    }
}
