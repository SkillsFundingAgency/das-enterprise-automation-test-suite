using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsApprovedPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Apprentice details approved";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");
        private By ClickDynamicHomeLink => By.CssSelector(".das-navigation__list-item");
        public ApprenticeDetailsApprovedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public DynamicHomePages ClickHome()
        {
            _formCompletionHelper.ClickElement(ClickDynamicHomeLink);
            return new DynamicHomePages(_context);
        }
    }
}