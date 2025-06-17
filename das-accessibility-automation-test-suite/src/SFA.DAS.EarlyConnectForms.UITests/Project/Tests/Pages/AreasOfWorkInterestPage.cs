using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class AreasOfWorkInterestPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What areas of work interest you? (optional)";
        private static By AgricultureCheckBox => By.CssSelector("#sector-1");
        private static By BusinessSalesLegalCheckBox => By.CssSelector("#sector-2");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public SchoolCollegePage SelectAnyAreaInterestToYou()
        {
            formCompletionHelper.SelectCheckbox(AgricultureCheckBox);
            formCompletionHelper.SelectCheckbox(BusinessSalesLegalCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new SchoolCollegePage(context);
        }
    }
}
