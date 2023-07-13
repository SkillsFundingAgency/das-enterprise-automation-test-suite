using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SetYourEmployerAccountNamePage : RegistrationBasePage
    {
        protected override string PageTitle => "Set your employer account name";
        protected override By ContinueButton => By.CssSelector("#accept");

        public SetYourEmployerAccountNamePage(ScenarioContext context) : base(context) => VerifyPage();

        public YourAccountNameHasBeenChangedPage SelectoptionNo()
        {
            formCompletionHelper.SelectRadioOptionByText("No, I want to use my organisation name as my employer account name");
            Continue();
            return new YourAccountNameHasBeenChangedPage(context);
        }
    }
}
