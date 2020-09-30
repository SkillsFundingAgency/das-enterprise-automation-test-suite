using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class ProviderSummaryPage : FATV2BasePage
    {
        protected override string PageTitle => objectContext.GetProviderName();

        public ProviderSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

    }
}
