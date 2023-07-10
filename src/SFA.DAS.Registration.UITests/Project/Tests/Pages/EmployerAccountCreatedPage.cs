using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EmployerAccountCreatedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Employer account created";
        protected override By ContinueButton => By.CssSelector("#accept");
        private static By GoToYourEmployerAccountHomepage => By.LinkText("Go to your employer account homepage"); 

        public EmployerAccountCreatedPage(ScenarioContext context) : base(context) => VerifyPage();

        public YourOrganisationsAndAgreementsPage GoToAcceptTheAgreementLink()
        {
            formCompletionHelper.ClickLinkByText("accept the agreement");
            return new YourOrganisationsAndAgreementsPage(context);
        }

        public HomePage SelectGoToYourEmployerAccountHomepage()
        {
            formCompletionHelper.Click(GoToYourEmployerAccountHomepage);
            return new HomePage(context);
        }
    }
}
