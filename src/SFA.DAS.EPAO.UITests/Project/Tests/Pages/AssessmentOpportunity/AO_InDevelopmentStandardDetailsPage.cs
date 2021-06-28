using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_InDevelopmentStandardDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Journeyman bookbinder";

        public AO_InDevelopmentStandardDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AO_InDevelopmentStandardDetailsPage IsInDevelopmentStandardDetailsPageDisplayed()
        {
            return this;
        }
    }
}
