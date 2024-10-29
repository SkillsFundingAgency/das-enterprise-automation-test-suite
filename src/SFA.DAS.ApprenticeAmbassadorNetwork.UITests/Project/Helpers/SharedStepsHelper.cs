using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using System.Collections.Generic;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers
{
    public class SharedStepsHelper(ScenarioContext context)
    {
        private string EventTitlesKey = "AanAdminStepsHelper.EventTitlesKey";

        public List<string> GetAllEventTitles(SearchEventsBasePage page)
        {
            if (context.ContainsKey(EventTitlesKey))
            {
                return context.Get<List<string>>(EventTitlesKey);
            }

            var eventTitles = page.GetEventTitles();

            while (page.HasNextPage())
            {
                page.ClickNextPage();
                var titles = page.GetEventTitles();
                eventTitles.AddRange(titles);
            }

            context.Add(EventTitlesKey, eventTitles);
            return eventTitles;
        }

        public void ClearEventTitleCache()
        {
            if (context.ContainsKey(EventTitlesKey))
            {
                context.Remove(EventTitlesKey);
            }
        }
    }
}
