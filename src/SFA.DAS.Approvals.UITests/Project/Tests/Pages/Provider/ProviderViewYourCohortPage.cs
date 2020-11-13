using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderViewYourCohortPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View your cohort";
        private By ViewApprenticeLink => By.LinkText("View");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderViewYourCohortPage(ScenarioContext context) : base(context) => _context = context;

        public int TotalNoOfApprentices() => pageInteractionHelper.FindElements(ViewApprenticeLink).Count;

        internal ProviderViewApprenticeDetailsPage SelectViewApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> viewApprenticeLinks = pageInteractionHelper.FindElements(ViewApprenticeLink);
            formCompletionHelper.ClickElement(viewApprenticeLinks[apprenticeNumber]);
            return new ProviderViewApprenticeDetailsPage(_context);
        }
    }
}
