using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AddATrainingProviderPage : RegistrationBasePage
    {
        protected override string PageTitle => "Add a training provider";
        protected override By ContinueButton => By.CssSelector("#submit-add-a-paye-scheme-button");

        public AddATrainingProviderPage(ScenarioContext context) : base(context) => VerifyPage();

        public EmployerAccountCreatedPage AddTrainingProviderNow()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes, I'll add a training provider now");
            Continue();
            return new EmployerAccountCreatedPage(context);
        }

        public EmployerAccountCreatedPage AddTrainingProviderLater()
        {
            formCompletionHelper.SelectRadioOptionByText("No, I want to finish setting up my account and add one later");
            Continue();
            return new EmployerAccountCreatedPage(context);
        }

    }
}
