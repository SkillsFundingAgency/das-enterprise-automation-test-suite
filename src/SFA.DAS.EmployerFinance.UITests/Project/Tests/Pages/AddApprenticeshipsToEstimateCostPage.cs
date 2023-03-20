using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class AddApprenticeshipsToEstimateCostPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Add apprenticeships to estimate cost";

        private By ApprenticeshipCombobox => By.CssSelector(".govuk-checkboxes__label[for='IsTransferFunded']");

        private static By SearchField => By.CssSelector("#choose-apprenticeship");

        private static By Standard => By.CssSelector("ul#choose-apprenticeship__listbox > li");

        private static By NoOfApprentice => By.CssSelector("input#no-of-app");

        private static By StartDateMonth => By.CssSelector("input#startDateMonth");

        private static By StartDateYear => By.CssSelector("input#startDateYear");

        private static By SaveButton => By.CssSelector("#save");

        public AddApprenticeshipsToEstimateCostPage(ScenarioContext context) : base(context) => VerifyPage();

        public EstimatedCostsPage Add()
        {
            var date = DateTime.Now;
            formCompletionHelper.ClickElement(ApprenticeshipCombobox);
            formCompletionHelper.EnterText(SearchField, "Retail manager, Level: 4 (Standard)");
            pageInteractionHelper.FocusTheElement(Standard);
            formCompletionHelper.Click(Standard);
            formCompletionHelper.EnterText(NoOfApprentice, 1);
            formCompletionHelper.EnterText(StartDateMonth, date.Month);
            formCompletionHelper.EnterText(StartDateYear, date.Year);
            formCompletionHelper.Click(SaveButton);
            return new EstimatedCostsPage(context);
        }
    }
}
