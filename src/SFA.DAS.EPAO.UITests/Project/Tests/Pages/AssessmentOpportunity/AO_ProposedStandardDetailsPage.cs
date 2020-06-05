using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_ProposedStandardDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Equestrian athlete";

        public AO_ProposedStandardDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AO_ProposedStandardDetailsPage IsProposedStandardDetailsPageDisplayed() => this;
    }
}
