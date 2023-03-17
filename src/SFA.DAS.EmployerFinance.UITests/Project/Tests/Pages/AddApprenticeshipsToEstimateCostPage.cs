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

        private By ApprenticeshipInputBox => By.XPath("//label[@class='govuk-label govuk-label--s'][1]");

        private By NoOfApprentice => By.CssSelector("input#no-of-app");

        private By StartDateMonth => By.CssSelector("input#startDateMonth");

        private By StartDateYear => By.CssSelector("input#startDateYear");

        private By SaveButton => By.CssSelector("#save");

        public AddApprenticeshipsToEstimateCostPage(ScenarioContext context) : base(context) => VerifyPage();

        public EstimatedCostsPage Add()
        {
            var date = DateTime.Now; 
            
            javaScriptHelper.ClickElement(ApprenticeshipCombobox);
            javaScriptHelper.SetTextUsingJavaScript(ApprenticeshipInputBox, "software tester");
            formCompletionHelper.EnterText(NoOfApprentice, 1);
            formCompletionHelper.EnterText(StartDateMonth, date.Month);
            formCompletionHelper.EnterText(StartDateYear, date.Year);
            formCompletionHelper.Click(SaveButton);
            return new EstimatedCostsPage(context);
        }
    }
}
