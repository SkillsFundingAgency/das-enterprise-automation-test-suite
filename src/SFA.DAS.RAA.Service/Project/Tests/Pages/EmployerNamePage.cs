using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class EmployerNamePage(ScenarioContext context) : EmployerNameBasePage(context)
    {
        protected override string PageTitle => "What employer name do you want to go on the vacancy?";
    }
}
