using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class RemovedFromCharityRegisterPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from any charity register?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RemovedFromCharityRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InvestigatedDueToSafeGuardingIssuesPage SelectYesAndEnterInformationForRemovedFromCharityRegister()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.RemovedFromCharityRegister);
            return new InvestigatedDueToSafeGuardingIssuesPage(_context);
        }
    }
}