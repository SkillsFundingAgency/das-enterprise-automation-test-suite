using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderManageTheStandardsYouDeliverPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage the standards you deliver";

        private static By AddAStandard => By.LinkText("Add a standard");

        public ProviderManageTheStandardsYouDeliverPage(ScenarioContext context) : base(context) { }

        public SelectStandardPage ClickAddAStandardLink()
        {
            formCompletionHelper.Click(AddAStandard);
            return new SelectStandardPage(context);
        }
    }
}
