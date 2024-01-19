using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ResultsPage(ScenarioContext context) : ApprenticeBasePage(context)
    {
        protected override string PageTitle => "Results";
    }
}
