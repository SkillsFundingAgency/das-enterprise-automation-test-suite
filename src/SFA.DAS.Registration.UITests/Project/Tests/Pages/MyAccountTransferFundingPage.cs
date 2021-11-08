using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public partial class MyAccountTransferFundingPage : RegistrationBasePage
    {
        protected override string PageTitle => "My accounts";

        public MyAccountTransferFundingPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}