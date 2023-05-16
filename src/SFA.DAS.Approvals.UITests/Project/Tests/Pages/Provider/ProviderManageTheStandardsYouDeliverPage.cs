using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderManageTheStandardsYouDeliverPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage the standards you deliver";
        private By AddAStandard => By.LinkText("Add a standard");

        public ProviderManageTheStandardsYouDeliverPage(ScenarioContext context) : base(context) { }

        public ProviderSelectAStandardPage ClickAddAStandardLink()
        {
            formCompletionHelper.Click(AddAStandard);
            return new ProviderSelectAStandardPage(context);
        }
    }
}
