using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPermissionsPage : BasePage
    {
        protected override string PageTitle => "Confirm permissions";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion
        
        private By ConfirmButton => By.CssSelector(".govuk-button");

        public ConfirmTrainingProviderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal PermissionsUpdatedPage ConfirmTrainingProviderPermissions()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new PermissionsUpdatedPage(_context);
        }
    }
}

