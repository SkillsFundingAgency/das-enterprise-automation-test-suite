using SFA.DAS.RoatpAdmin.Service.Project.Helpers;
using SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers
{
    public class NewRoatpAdminStepsHelper(ScenarioContext context) : RoatpAdminStepsHelper(context)
    {
        public SearchPage SearchForATrainingProvider() => new StaffDashboardPage(context, true).SearchForATrainingProvider();
    }
}