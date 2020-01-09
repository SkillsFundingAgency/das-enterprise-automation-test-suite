using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_ProposedStandardDetailsPage : BasePage
    {
        protected override string PageTitle => "Equine Athlete";

        public AO_ProposedStandardDetailsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        public AO_ProposedStandardDetailsPage IsProposedStandardDetailsPageDisplayed()
        {
            return this;
        }
    }
}
