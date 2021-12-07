using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CannotFindApprenticePage : EPAO_BasePage
    {
        protected override string PageTitle => "We cannot find the apprentice details";
        private readonly ScenarioContext _context;

        public AS_CannotFindApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}