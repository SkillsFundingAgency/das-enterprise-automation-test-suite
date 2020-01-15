using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_EditEmployerAddress : AS_BasePage
    {
        protected override string PageTitle => "Edit the employer's address";
        private readonly ScenarioContext _context;

        public AS_EditEmployerAddress(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
