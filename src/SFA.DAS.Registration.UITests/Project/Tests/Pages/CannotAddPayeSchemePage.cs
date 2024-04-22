using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CannotAddPayeSchemePage : RegistrationBasePage
    {
        protected override string PageTitle => "Add PAYE Scheme";
        protected static By CloseButton => By.LinkText("Close");
        public CannotAddPayeSchemePage(ScenarioContext context) : base(context) => VerifyPage();

        public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
        {
            formCompletionHelper.Click(CloseButton);
            return new CreateYourEmployerAccountPage(context);
        }
    }
}
