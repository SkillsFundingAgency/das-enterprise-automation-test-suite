using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAuthCodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Check your email";
    }
}
