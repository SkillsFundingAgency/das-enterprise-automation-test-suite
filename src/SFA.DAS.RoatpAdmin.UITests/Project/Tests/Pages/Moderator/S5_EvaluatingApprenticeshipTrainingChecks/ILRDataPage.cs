using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ILRDataPage : ModeratorBasePage
    {
        protected override string PageTitle => "Individualised Learner Record (ILR) data";
        private readonly ScenarioContext _context;

        public ILRDataPage(ScenarioContext context) : base(context) => _context = context;

        public IndividualAccountableForILRDataPage SelectPassAndContinueForILRDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new IndividualAccountableForILRDataPage(_context);
        }

        public IndividualAccountableForILRDataPage SelectFailAndContinueForILRDataPage()
        {
            SelectFailAndContinueToSubSection();
            return new IndividualAccountableForILRDataPage(_context);
        }
    }
}