using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SetYourEmployerAccountNamePage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your employer account name";
        protected override By ContinueButton => By.CssSelector("#accept");
        protected static By NewNameTextBox => By.Id("NewName");

        public SetYourEmployerAccountNamePage(ScenarioContext context) : base(context) => VerifyPage();

        public YourAccountNameHasBeenChangedPage SelectoptionYes()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes, I want to use my organisation name as my employer account name");
            Continue();
            return new YourAccountNameHasBeenChangedPage(context);
        }

        public ConfirmYourNewAccountNamePage SelectoptionNo(string newAccountName)
        {
            formCompletionHelper.SelectRadioOptionByText("No, I want to change my employer account name");

            formCompletionHelper.EnterText(NewNameTextBox, newAccountName);

            objectContext.UpdateOrganisationName(newAccountName);

            Continue();

            return new ConfirmYourNewAccountNamePage(context);
        }

        public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
        {
            formCompletionHelper.Click(BackLink);
            return new CreateYourEmployerAccountPage(context);
        }
    }
}
