using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class IndividualAccountableForILRDataPage : ModeratorBasePage
    {
        protected override string PageTitle => "Who is the individual accountable for submitting ILR data for your organisation?";

        public IndividualAccountableForILRDataPage(ScenarioContext context) : base(context) { }
    }
}