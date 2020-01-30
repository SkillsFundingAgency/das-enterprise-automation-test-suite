using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class InvestigatedDueToSafeGuardingIssuesPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation been investigated due to safeguarding issues in the last 3 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_InvestigatedDueToSafeGuardingIssues => By.Id("CC-28.1");

        public InvestigatedDueToSafeGuardingIssuesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InvestigatedDueToWhistleBlowingIssuesPage SelectYesEnterInformationForInvestigatedDueToSafeGuardingIssuesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_InvestigatedDueToSafeGuardingIssues, applydataHelpers.InvestigatedDueToSafeGuardingIssues);
            Continue();
            return new InvestigatedDueToWhistleBlowingIssuesPage(_context);
        }
    }
}