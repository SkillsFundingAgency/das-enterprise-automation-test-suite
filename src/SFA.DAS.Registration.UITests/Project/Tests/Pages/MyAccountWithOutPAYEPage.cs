using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class MyAccountWithOutPayePage : RegistrationBasePage
    {
        protected override string PageTitle => "MY ACCOUNT";

        public MyAccountWithOutPayePage(ScenarioContext context) : base(context) => VerifyPage();

        public AddAPAYESchemePage AddYourPAYEScheme()
        {
            formCompletionHelper.ClickLinkByText("Add your PAYE scheme");
            return new AddAPAYESchemePage(context);
        }
    }
}