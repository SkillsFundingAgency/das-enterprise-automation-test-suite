using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class RemovedFromCharityRegisterPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from any charity register?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion


        private By LongTextArea_RemovedFromCharityRegister => By.Id("CC-27.1");

        public RemovedFromCharityRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InvestigatedDueToSafeGuardingIssuesPage SelectYesAndEnterInformationForRemovedFromCharityRegister()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_RemovedFromCharityRegister, applydataHelpers.RemovedFromCharityRegister);
            Continue();
            return new InvestigatedDueToSafeGuardingIssuesPage(_context);
        }
    }
}