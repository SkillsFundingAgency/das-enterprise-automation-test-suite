using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorLoginStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly DfeAdminLoginStepsHelper _dfeAdminLoginStepsHelper;

        public AssessorLoginStepsHelper(ScenarioContext context)
        {
            _context = context;
            _dfeAdminLoginStepsHelper = new DfeAdminLoginStepsHelper(context);
        }

        public RoatpAssessorApplicationsHomePage Assessor1Login() { _dfeAdminLoginStepsHelper.LoginToAsAssessor1(); return new(_context); }

        public RoatpAssessorApplicationsHomePage Assessor2Login() { _dfeAdminLoginStepsHelper.LoginToAsAssessor2(); return new(_context); }
    }
}
