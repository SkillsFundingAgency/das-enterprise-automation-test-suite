using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class FinancialEvidencePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Financial evidence";

        private static By InputNumbers => By.CssSelector(".govuk-input[type='number']");

        public FinancialEvidencePage(ScenarioContext context) : base(context) => VerifyPage();

        public LatestFullFinancialForTwelveMonthsPage EnterInputsForFinancialEvidenceAndContinue()
        {
            var inputNumbersFields = pageInteractionHelper.FindElements(InputNumbers).ToList();

            foreach (var inputNumber in inputNumbersFields) formCompletionHelper.EnterText(inputNumber, RoatpApplyDataHelpers.GenerateRandomWholeNumber(4));

            Continue();

            return new LatestFullFinancialForTwelveMonthsPage(context);
        }
    }
}
