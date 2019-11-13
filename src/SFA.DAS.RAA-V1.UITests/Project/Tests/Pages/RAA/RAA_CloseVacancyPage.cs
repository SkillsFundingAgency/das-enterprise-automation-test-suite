using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_CloseVacancyPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Close";

        public RAA_CloseVacancyPage(ScenarioContext context) : base(context) { }

        public void CloseVacancy()
        {
            formCompletionHelper.ClickButtonByText("Close opportunity", "Close vacancy");
        }
    }
}
