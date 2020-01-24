using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class FinancialEvidencePage : RoatpBasePage
    {
        protected override string PageTitle => "Financial evidence";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TotalAnnualTurnOver => By.CssSelector("#FH-140");
        private By TotalDepreciationCharges => By.CssSelector("#FH-150");
        private By TotalProfitAndLoss => By.CssSelector("#FH-160");
        private By TotalDividends => By.CssSelector("#FH-170");
        private By TotalCurrentAssets => By.CssSelector("#FH-180");
        private By TotalCurrentLiabilities => By.CssSelector("#FH-190");
        private By TotalBorrowings => By.CssSelector("#FH-200");
        private By TotalnetAssets => By.CssSelector("#FH-210");
        private By TotalIntangibleAssets => By.CssSelector("#FH-220");

        public FinancialEvidencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public LatestFullFinancialForTwelveMonthsPage EnterInputsForFinancialEvidenceAndContinue()
        {
            formCompletionHelper.EnterText(TotalAnnualTurnOver, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalDepreciationCharges, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalProfitAndLoss, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalDividends, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalCurrentAssets, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalCurrentLiabilities, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalBorrowings, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalnetAssets, applydataHelpers.GenerateRandomNumber(4));
            formCompletionHelper.EnterText(TotalIntangibleAssets, applydataHelpers.GenerateRandomNumber(4));
            Continue();
            return new LatestFullFinancialForTwelveMonthsPage(_context);
        }

    }
}
