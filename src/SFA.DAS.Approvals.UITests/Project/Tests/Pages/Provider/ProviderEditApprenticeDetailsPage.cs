using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _datahelper;
        #endregion

        private By Uln => By.Id("Uln");

        private By SaveButton => By.CssSelector(".govuk-button");

        public ProviderEditApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public ProviderReviewYourCohortPage EnterUlnAndSave()
        {
            _formCompletionHelper.EnterText(Uln, _datahelper.Uln());
            _formCompletionHelper.ClickElement(SaveButton);
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
