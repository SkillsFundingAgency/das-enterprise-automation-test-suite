using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{
    public class FinancialEvidencePage : RoatpBasePage
    {
        protected override string PageTitle => "Financial evidence";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By InputNumbers => By.CssSelector(".govuk-input[type='number']");

        public FinancialEvidencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public LatestFullFinancialForTwelveMonthsPage EnterInputsForFinancialEvidenceAndContinue()
        {
            var inputNumbersFields = pageInteractionHelper.FindElements(InputNumbers).ToList();

            foreach (var inputNumber in inputNumbersFields)
            {
                formCompletionHelper.EnterText(inputNumber, applydataHelpers.GenerateRandomWholeNumber(4));
            }

            Continue();
            return new LatestFullFinancialForTwelveMonthsPage(_context);
        }
    }
}
