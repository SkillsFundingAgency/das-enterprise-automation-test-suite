using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationApplicationsPage : ModeratorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";
        private readonly ScenarioContext _context;

        public By AssignToMeLinkForMainProvider => By.XPath("//td[contains(text(),'7TAO ENGINEERING UK LIMITED')]//following-sibling::td//a");
        public By AssignToMeLinkForSupportingProvider => By.XPath("//td[contains(text(),'ARTHUR MUREVERWI')]//following-sibling::td//a");
        public By AssignToMeLinkForEmployerProvider => By.XPath("//td[contains(text(),'SHOCKOUT ACADEMY')]//following-sibling::td//a");

        public By ModerationTab => By.CssSelector("a[href='/Dashboard/InModeration']");

        public By ClarificationTab => By.CssSelector("a[href='/Dashboard/InClarification']");

        public By OutcomeTab => By.CssSelector("a[href='/Dashboard/Outcome']");

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
