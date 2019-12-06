using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        public FAA_ApprenticeSearchResultsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
