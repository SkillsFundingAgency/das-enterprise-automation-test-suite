using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class WhosInControlFailedToPayBackFundsPage : RoatpBasePage
    {
        protected override string PageTitle => "failed to pay back funds in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlFailedToPayBackFundsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlInvestigatedForFraudOrIrregularitiesPage SelectYesEnterInformationForFailedToPayBackFundAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlFailedToPayBackFunds);
            return new WhosInControlInvestigatedForFraudOrIrregularitiesPage(_context);
        }
    }
}
