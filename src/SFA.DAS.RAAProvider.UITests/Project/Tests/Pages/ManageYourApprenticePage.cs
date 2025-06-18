using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class ManageYourApprenticePage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Manage your apprentices";

    }
}
