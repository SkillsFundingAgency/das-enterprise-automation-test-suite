using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ShareApplicationPreviewPage : RAA_ChangeVacancyPreviewPage
    {
        protected override string PageTitle => "You have shared";

        public RAA_ShareApplicationPreviewPage(ScenarioContext context) : base(context) { }
    }

    
}