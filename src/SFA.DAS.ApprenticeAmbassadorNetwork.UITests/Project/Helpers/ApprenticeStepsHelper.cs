using System.Collections.Generic;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers
{
    public class ApprenticeStepsHelper(ScenarioContext context)
    {
        private readonly SharedStepsHelper _sharedStepsHelper = new SharedStepsHelper(context);

        public List<NetworkEventSearchResult> GetAllEventTitles()
        {
            var manageEvents = new SearchNetworkEventsPage(context);
            return _sharedStepsHelper.GetAllSearchResults(manageEvents);
        }

        public void ClearEventTitleCache()
        {
            _sharedStepsHelper.ClearSearchResultsCache();
        }
    }
}
