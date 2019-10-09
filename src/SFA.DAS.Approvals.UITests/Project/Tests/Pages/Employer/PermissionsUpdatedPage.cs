using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PermissionsUpdatedPage : BasePage
    {
        protected override string PageTitle => "Permissions updated";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        public PermissionsUpdatedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        private By GoToHomePageOptions => By.CssSelector(".govuk-radios__label");
        private By ContinueButton => By.CssSelector(".govuk-button");

        internal HomePage GoToHomePage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToHomePageOptions, "choice-3");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new HomePage(_context);
        }
    }
}

