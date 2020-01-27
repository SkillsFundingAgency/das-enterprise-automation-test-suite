using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class InvestigatedDueToWhistleBlowingIssuesPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation been investigated due to whistleblowing issues in the last 3 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion


        private By LongTextArea_InvestigatedDueToWhistleBlowingIssues => By.Id("CC-29.1");

        public InvestigatedDueToWhistleBlowingIssuesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InsolvencyOrWindingUpProceedingsPage SelectYesEnterInformationForInvestigatedDueToWhistleBlowingAndContinue()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_InvestigatedDueToWhistleBlowingIssues, applydataHelpers.InvestigatedDueToWhistleBlowingIssues);
            Continue();
            return new InsolvencyOrWindingUpProceedingsPage(_context);
        }
    }
}