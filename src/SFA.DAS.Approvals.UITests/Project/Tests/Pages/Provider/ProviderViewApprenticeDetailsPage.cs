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

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderViewApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderViewYourCohortPage SelectReturnToCohortView()
        {
            formCompletionHelper.ClickElement(ReturnToCohortViewLink);
            return new ProviderViewYourCohortPage(_context);
        }

        internal List<IWebElement> GetAllEditBoxes()
        {
            return pageInteractionHelper.FindElements(InputBox);
        }
    }
}
