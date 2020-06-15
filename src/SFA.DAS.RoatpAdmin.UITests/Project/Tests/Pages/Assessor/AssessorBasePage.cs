using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public abstract class AssessorBasePage : RoatpBasePage
    {
        private readonly ScenarioContext _context;

        protected AssessorBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationAssessmentOverviewPage SelectPassAndContinue()
        {
            SelectRadioOptionByText("Pass");
            Continue();
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}
