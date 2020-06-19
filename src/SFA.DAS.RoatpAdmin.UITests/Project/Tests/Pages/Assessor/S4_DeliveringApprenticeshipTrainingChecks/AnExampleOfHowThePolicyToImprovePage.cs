using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class AnExampleOfHowThePolicyToImprovePage : AssessorBasePage
    {
        protected override string PageTitle => "An example of how the policy is used to improve employee sector expertise";

        private readonly ScenarioContext _context;
        public AnExampleOfHowThePolicyToImprovePage(ScenarioContext context) : base(context) => _context = context;

        public AnExampleOfHowThePolicyToMaintainPage SelectPassAndContinueInAnExampleOfHowThePolicyToImprovePage()
        {
            SelectPassAndContinueToSubSection();
            return new AnExampleOfHowThePolicyToMaintainPage(_context);
        }
    }
}