using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDetailsOfILRDataMismatchPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Details of ILR data mismatch";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FixILRMismatchOptions => By.CssSelector(".selection-button-radio");

        protected override By ContinueButton => By.Id("fix-mismatch");

        public ProviderDetailsOfILRDataMismatchPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderChangeApprenticeDetailsPage RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-Confirm");
            Continue();
            return new ProviderChangeApprenticeDetailsPage(_context);
        }

        internal ProviderAccessDeniedPage ClickContinueNavigateToProviderAccessDeniedPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-Confirm");
            Continue();            
            return new ProviderAccessDeniedPage(_context);
        }

        internal ProviderApprenticeDetailsPage ClickLeaveForNow()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-None");
            Continue();
            return new ProviderApprenticeDetailsPage(_context);
        }

        public ProviderDetailsOfILRDataMismatchPage SelectILRDataMismatchOptions()
        {
            Continue();
            return this;
        }

    }
}
