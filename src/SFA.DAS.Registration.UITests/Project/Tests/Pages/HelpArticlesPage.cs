using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HelpArticlesPage : RegistrationBasePage
    {
        protected override string PageTitle => "Help articles";

        public HelpArticlesPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}