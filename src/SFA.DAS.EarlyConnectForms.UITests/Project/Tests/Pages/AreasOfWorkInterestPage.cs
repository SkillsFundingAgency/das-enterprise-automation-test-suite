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
        private static By BackButton => By.CssSelector(".govuk-back-link");
        public SchoolCollegePage SelectAnyAreaInterestToYou()
        {
            formCompletionHelper.SelectCheckbox(AgricultureCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new SchoolCollegePage(context);
        }
        public TelephonePage SelectBackButton()
        {
            formCompletionHelper.ClickElement(BackButton);
            return new TelephonePage(context);
        }
        public CheckYourAnswerPage ChangeIndustry()
        {
            formCompletionHelper.SelectCheckbox(AgricultureCheckBox);
            formCompletionHelper.SelectCheckbox(BusinessSalesLegalCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new CheckYourAnswerPage(context);
        }
    }
}
