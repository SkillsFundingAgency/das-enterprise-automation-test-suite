using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
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
