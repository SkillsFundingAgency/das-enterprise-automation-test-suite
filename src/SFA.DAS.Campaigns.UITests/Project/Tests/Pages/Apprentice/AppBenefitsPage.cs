using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AppBenefitsPage : ApprenticeBasePage
    {
        protected override string PageTitle => "What are the benefits of an apprenticeship?";
        private readonly ScenarioContext _context;
        public AppBenefitsPage(ScenarioContext context) : base(context){ }
    }
}
