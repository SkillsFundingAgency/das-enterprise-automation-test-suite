using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class SystemsAndProcessesToCollectApprenticeshipDataPage : AssessorBasePage
    {
        protected override string PageTitle => "Systems and processes to collect apprenticeship data";
        
        public SystemsAndProcessesToCollectApprenticeshipDataPage(ScenarioContext context) : base(context) { }

        public ILRDataPage SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new ILRDataPage(context);
        }
    }
}