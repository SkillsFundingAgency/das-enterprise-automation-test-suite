using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ILRDataPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Individualised Learner Record (ILR) data";

        public IndividualAccountableForILRDataPage SelectPassAndContinueForILRDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new IndividualAccountableForILRDataPage(context);
        }
    }
}