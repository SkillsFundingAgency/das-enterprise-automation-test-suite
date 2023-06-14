using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderSaveStandardPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.ClassName("govuk-caption-xl");
        protected override string PageTitle => "Add standard";

        public ProviderSaveStandardPage(ScenarioContext context) : base(context) { }

        public ProviderManageTheStandardsYouDeliverPage SaveStandard()
        {
            Continue();
            return new ProviderManageTheStandardsYouDeliverPage(context);
        }
    }
}
