using SFA.DAS.EsfaAdmin.Service.Project.Helpers;
using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers
{
    public class NewRoatpAdminStepsHelper : RoatpAdminStepsHelper
    {
        private readonly ScenarioContext _context;

        public NewRoatpAdminStepsHelper(ScenarioContext context) : base(context) => _context = context;

        public SearchPage SearchForATrainingProvider() => new StaffDashboardPage(_context, true).SearchForATrainingProvider();
    }
}