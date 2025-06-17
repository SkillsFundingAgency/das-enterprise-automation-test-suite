using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class NotificationsSettingsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Notification settings";
    }
}
