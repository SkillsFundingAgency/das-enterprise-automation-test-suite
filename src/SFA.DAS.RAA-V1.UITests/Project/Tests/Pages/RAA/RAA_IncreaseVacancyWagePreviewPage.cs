using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_IncreaseVacancyWagePreviewPage : RAA_ChangeVacancyPreviewPage
    {
        protected override string PageTitle => "You have successfully increased the wage for this vacancy";

        public RAA_IncreaseVacancyWagePreviewPage(ScenarioContext context) : base(context) { }
    }
}
