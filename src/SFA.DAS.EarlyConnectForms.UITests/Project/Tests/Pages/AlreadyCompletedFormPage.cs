using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class AlreadyCompletedFormPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "You have already completed this form";
    }
}
