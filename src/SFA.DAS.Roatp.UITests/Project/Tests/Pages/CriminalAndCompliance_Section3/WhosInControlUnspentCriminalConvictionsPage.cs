using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class WhosInControlUnspentCriminalConvictionsPage : RoatpBasePage
    {
        protected override string PageTitle => "any unspent criminal convictions?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlUnspentCriminalConvictionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlFailedToPayBackFundsPage SelectYesEnterInformationForUnspentCriminalConvicitionAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.UnspentCriminalConvictions);
            return new WhosInControlFailedToPayBackFundsPage(_context);
        }
    }
}
