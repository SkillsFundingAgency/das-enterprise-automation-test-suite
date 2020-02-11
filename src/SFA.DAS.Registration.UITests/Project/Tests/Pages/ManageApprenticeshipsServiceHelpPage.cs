using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ManageApprenticeshipsServiceHelpPage : RegistrationBasePage
    {
        protected override string PageTitle => "Help articles";

        public ManageApprenticeshipsServiceHelpPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}