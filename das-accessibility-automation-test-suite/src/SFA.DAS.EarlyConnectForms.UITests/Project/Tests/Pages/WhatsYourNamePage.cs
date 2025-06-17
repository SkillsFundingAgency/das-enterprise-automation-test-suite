using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class WhatsYourNamePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What's your name?";
        private static By FirstNameTextField => By.CssSelector("#FirstName");
        private static By LastNameTextField => By.CssSelector("#LastName");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");

        public DateOfBirthPage EnterFirstAndLastNames()
        {
            formCompletionHelper.EnterText(FirstNameTextField, earlyConnectDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameTextField, earlyConnectDataHelper.Lastname);
            formCompletionHelper.ClickElement(ContinueButton);
            return new DateOfBirthPage(context);
        }
    }


}
