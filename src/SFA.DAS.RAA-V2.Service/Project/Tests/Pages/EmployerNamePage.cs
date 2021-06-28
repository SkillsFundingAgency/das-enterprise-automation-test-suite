using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerNamePage : EmployerNameBasePage
    {
        protected override string PageTitle => "What employer name do you want to go on the vacancy?";

        public EmployerNamePage(ScenarioContext context) : base(context) { }
    }
}
