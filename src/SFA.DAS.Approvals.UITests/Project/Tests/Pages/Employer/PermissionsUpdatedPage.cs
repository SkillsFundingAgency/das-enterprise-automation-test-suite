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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public PermissionsUpdatedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        private By GoToHomePageOptions => By.CssSelector(".govuk-radios__label");

        internal HomePage GoToHomePage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToHomePageOptions, "choice-3");
            Continue();
            return new HomePage(_context);
        }
    }
}
