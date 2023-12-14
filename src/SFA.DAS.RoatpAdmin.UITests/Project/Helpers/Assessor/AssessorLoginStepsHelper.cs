using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorLoginStepsHelper(ScenarioContext context)
    {
        private readonly DfeAdminLoginStepsHelper _dfeAdminLoginStepsHelper = new DfeAdminLoginStepsHelper(context);

        public RoatpAssessorApplicationsHomePage Assessor1Login() { _dfeAdminLoginStepsHelper.LoginToAsAssessor1(); return new(context); }

        public RoatpAssessorApplicationsHomePage Assessor2Login() { _dfeAdminLoginStepsHelper.LoginToAsAssessor2(); return new(context); }
    }
}
