using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AppBenefitsPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";
        private readonly ScenarioContext _context;
        public AppBenefitsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
