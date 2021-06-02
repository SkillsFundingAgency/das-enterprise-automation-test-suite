using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class InvestigatedDueToSafeGuardingIssuesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been investigated due to safeguarding issues in the last 3 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InvestigatedDueToSafeGuardingIssuesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SubjectToInvestigationByESFAorPublicBodyPage SelectYesEnterInformationForInvestigatedDueToSafeGuardingIssuesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InvestigatedDueToSafeGuardingIssues);
            return new SubjectToInvestigationByESFAorPublicBodyPage(_context);
        }
    }
}