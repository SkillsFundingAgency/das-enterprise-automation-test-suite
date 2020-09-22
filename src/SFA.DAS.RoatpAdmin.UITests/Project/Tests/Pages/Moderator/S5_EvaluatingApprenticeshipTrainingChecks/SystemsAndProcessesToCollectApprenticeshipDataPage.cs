using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class SystemsAndProcessesToCollectApprenticeshipDataPage : ModeratorBasePage
    {
        protected override string PageTitle => "Systems and processes to collect apprenticeship data";
        private readonly ScenarioContext _context;

        public SystemsAndProcessesToCollectApprenticeshipDataPage(ScenarioContext context) : base(context) => _context = context;

        public ILRDataPage SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new ILRDataPage(_context);
        }
    }
}