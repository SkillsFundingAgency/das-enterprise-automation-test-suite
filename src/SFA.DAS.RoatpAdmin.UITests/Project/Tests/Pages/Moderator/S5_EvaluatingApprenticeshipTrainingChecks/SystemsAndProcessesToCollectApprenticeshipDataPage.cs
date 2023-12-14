using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class SystemsAndProcessesToCollectApprenticeshipDataPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Systems and processes to collect apprenticeship data";

        public ILRDataPage SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
        {
            SelectPassAndContinueToSubSection();
            return new ILRDataPage(context);
        }

        public ILRDataPage SelectFailAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
        {
            SelectFailAndContinueToSubSection();
            return new ILRDataPage(context);
        }
    }
}