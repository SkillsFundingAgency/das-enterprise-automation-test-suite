using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public  class AddATrainingProviderPage : RegistrationBasePage
    {
        protected override string PageTitle => "Add a training provider";
        protected override By ContinueButton => By.Id("submit-add-a-paye-scheme-button");
        public AddATrainingProviderPage(ScenarioContext context) : base(context) => VerifyPage();

        public EmployerAccountCreatedPage SelectoptionNo()
        {
            formCompletionHelper.SelectRadioOptionByText("No, I want to finish setting up my account and add one later");
            Continue();
            return new EmployerAccountCreatedPage(context);
        }

    }
}
