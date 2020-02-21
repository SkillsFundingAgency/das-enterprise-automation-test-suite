using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class InvestigatedDueToWhistleBlowingIssuesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been investigated due to whistleblowing issues in the last 3 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InvestigatedDueToWhistleBlowingIssuesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InsolvencyOrWindingUpProceedingsPage SelectYesEnterInformationForInvestigatedDueToWhistleBlowingAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InvestigatedDueToWhistleBlowingIssues);
            return new InsolvencyOrWindingUpProceedingsPage(_context);
        }
    }
}