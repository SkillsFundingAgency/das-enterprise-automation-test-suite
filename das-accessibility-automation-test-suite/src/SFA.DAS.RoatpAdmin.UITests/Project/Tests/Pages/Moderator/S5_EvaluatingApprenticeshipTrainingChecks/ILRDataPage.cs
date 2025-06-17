using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ILRDataPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Individualised Learner Record (ILR) data";

        public IndividualAccountableForILRDataPage SelectPassAndContinueForILRDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new IndividualAccountableForILRDataPage(context);
        }

        public IndividualAccountableForILRDataPage SelectFailAndContinueForILRDataPage()
        {
            SelectFailAndContinueToSubSection();
            return new IndividualAccountableForILRDataPage(context);
        }
    }
}