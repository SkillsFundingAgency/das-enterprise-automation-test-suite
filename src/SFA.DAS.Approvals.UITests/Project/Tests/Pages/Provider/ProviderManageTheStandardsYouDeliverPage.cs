using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderManageTheStandardsYouDeliverPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage the standards you deliver";

        private static By AddAStandard => By.LinkText("Add a standard");

        private static By StandardSelector(string text) => By.PartialLinkText(text);

        public ProviderManageTheStandardsYouDeliverPage(ScenarioContext context) : base(context) { }

        public SelectStandardPage ClickAddAStandardLink()
        {
            formCompletionHelper.Click(AddAStandard);
            return new SelectStandardPage(context);
        }

        public ProviderManageStandardPage SelectStandard(string text)
        {
            formCompletionHelper.Click(StandardSelector(text));

            return new ProviderManageStandardPage(context, text);
        }
    }

    public class ProviderManageStandardPage : ApprovalsBasePage
    {
        private readonly string _pageTitle;

        public ProviderManageStandardPage(ScenarioContext context, string standardname) : base(context, false) 
        {
            _pageTitle = standardname;

            VerifyPage();
        }

        protected override string PageTitle => _pageTitle;

        public void DeleteStandard()
        {
            formCompletionHelper.ClickLinkByText("Delete standard");
        }
    }
}
