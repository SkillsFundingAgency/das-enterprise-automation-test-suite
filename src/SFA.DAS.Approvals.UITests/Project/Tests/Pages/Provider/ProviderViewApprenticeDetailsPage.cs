using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    class ProviderViewApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "View apprentice details";
        private By returnToCohortViewLink => By.LinkText("Return to cohort view");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderViewApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ProviderViewYourCohortPage SelectReturnToCohortView()
        {
            _formCompletionHelper.ClickElement(returnToCohortViewLink);
            return new ProviderViewYourCohortPage(_context);
        }
    }
}