

using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class DateOfBirthPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is your date of birth?";
        private static By DayInputField => By.CssSelector("#Day");
        private static By MonthInputField => By.CssSelector("#Month");
        private static By YearInputField => By.CssSelector("#Year");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public DateOfBirthPage EnterValidDateOfBirth()
        {
            formCompletionHelper.EnterText(DayInputField, earlyConnectDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(MonthInputField, earlyConnectDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(YearInputField, earlyConnectDataHelper.DateOfBirthYear);
            formCompletionHelper.ClickElement(ContinueButton);
            return new DateOfBirthPage(context);
        }
    }
}
