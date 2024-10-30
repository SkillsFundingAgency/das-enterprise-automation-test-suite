using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using System.Collections.Generic;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers
{
    public class SharedStepsHelper(ScenarioContext context)
    {
        private string SearchResultsKey = "AanAdminStepsHelper.SearchResultsKey";

        public List<NetworkEventSearchResult> GetAllSearchResults(SearchEventsBasePage page)
        {
            if (context.ContainsKey(SearchResultsKey))
            {
                return context.Get<List<NetworkEventSearchResult>>(SearchResultsKey);
            }

            var eventTitles = page.GetSearchResults();

            while (page.HasNextPage())
            {
                page.ClickNextPage();
                var titles = page.GetSearchResults();
                eventTitles.AddRange(titles);
            }

            context.Add(SearchResultsKey, eventTitles);
            return eventTitles;
        }

        public void ClearSearchResultsCache()
        {
            if (context.ContainsKey(SearchResultsKey))
            {
                context.Remove(SearchResultsKey);
            }
        }
    }
}
