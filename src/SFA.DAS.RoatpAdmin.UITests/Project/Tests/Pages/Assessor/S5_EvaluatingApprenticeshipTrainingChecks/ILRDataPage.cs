using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ILRDataPage : AssessorBasePage
    {
        protected override string PageTitle => "Individualised Learner Record (ILR) data";
        private readonly ScenarioContext _context;

        public ILRDataPage(ScenarioContext context) : base(context) => _context = context;

        public IndividualAccountableForILRDataPage SelectPassAndContinueForILRDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new IndividualAccountableForILRDataPage(_context);
        }
    }
}