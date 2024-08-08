using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class MyTransferPledgesPage : RegistrationBasePage
    {
        protected override string PageTitle => "My transfer pledges";
        public MyTransferPledgesPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}