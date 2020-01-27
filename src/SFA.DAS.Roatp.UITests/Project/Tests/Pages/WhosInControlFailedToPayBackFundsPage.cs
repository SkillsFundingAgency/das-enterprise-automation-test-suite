using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhosInControlFailedToPayBackFundsPage : RoatpBasePage
    {
        protected override string PageTitle => "failed to pay back funds in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlFailedToPayBackFundsOrganisations => By.Id("CC-50.1");
        private By LongTextArea_WhosInControlFailedToPayBackFundsSoleTrader => By.Id("CC-51.1");

        public WhosInControlFailedToPayBackFundsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlInvestigatedForFraudOrIrregularitiesPage SelectYesEnterInformationForFailedToPayBackFundAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlFailedToPayBackFundsOrganisations) ? LongTextArea_WhosInControlFailedToPayBackFundsOrganisations : LongTextArea_WhosInControlFailedToPayBackFundsSoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlFailedToPayBackFunds);
            Continue();
            return new WhosInControlInvestigatedForFraudOrIrregularitiesPage(_context);
        }
    }
}
