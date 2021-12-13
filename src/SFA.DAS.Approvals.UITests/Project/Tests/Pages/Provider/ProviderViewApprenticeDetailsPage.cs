using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    class ProviderViewApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View apprentice details";

        private By ReturnToCohortViewLink => By.LinkText("Return to cohort view");

        private By InputBox => By.TagName("input");

        public ProviderViewApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

        internal ProvideViewApprenticesDetailsPage SelectReturnToCohortView()
        {
            formCompletionHelper.ClickElement(ReturnToCohortViewLink);
            return new ProvideViewApprenticesDetailsPage(_context);
        }

        internal List<IWebElement> GetAllEditBoxes()
        {
            return pageInteractionHelper.FindElements(InputBox);
        }
    }
}
