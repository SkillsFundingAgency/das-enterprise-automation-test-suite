using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApplicationPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Applying for an apprenticeship";

        public ApplicationPage(ScenarioContext context) : base(context) { }
    }
}
