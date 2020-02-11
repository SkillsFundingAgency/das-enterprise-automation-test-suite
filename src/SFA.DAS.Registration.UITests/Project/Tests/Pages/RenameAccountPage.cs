using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class RenameAccountPage : RegistrationBasePage
    {
        protected override string PageTitle => "Rename account";

        public RenameAccountPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}