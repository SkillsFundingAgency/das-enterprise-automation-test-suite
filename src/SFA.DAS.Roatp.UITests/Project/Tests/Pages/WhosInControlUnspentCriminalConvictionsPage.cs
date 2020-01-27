using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhosInControlUnspentCriminalConvictionsPage : RoatpBasePage
    {
        protected override string PageTitle => "any unspent criminal convictions?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_UnspentCriminalConvictionsOrganisations => By.Id("CC-40.1");
        private By LongTextArea_UnspentCriminalConvictionsSoleTrader => By.Id("CC-41.1");

        public WhosInControlUnspentCriminalConvictionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlFailedToPayBackFundsPage SelectYesEnterInformationForUnspentCriminalConvicitionAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_UnspentCriminalConvictionsOrganisations) ? LongTextArea_UnspentCriminalConvictionsOrganisations : LongTextArea_UnspentCriminalConvictionsSoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.UnspentCriminalConvictions);
            Continue();
            return new WhosInControlFailedToPayBackFundsPage(_context);
        }
    }
}
