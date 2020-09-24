using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class ProviderSummaryPage : FATV2BasePage
    {
        protected override string PageTitle => objectContext.GetProviderName();
        private readonly ScenarioContext _context;

        public ProviderSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
