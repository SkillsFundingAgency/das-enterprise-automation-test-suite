using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ChangeVacancyDatePreviewPage : RAA_ChangeVacancyPreviewPage
    {
        protected override string PageTitle => "Your changes have been saved successfully";

        public RAA_ChangeVacancyDatePreviewPage(ScenarioContext context) : base(context) { }
    }
}
