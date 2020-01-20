using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_RemoveUserPage : BasePage
    {
        protected override string PageTitle => "Remove user";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Locators
        private By RemoveThisUserLink => By.LinkText("Remove this user");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public AS_RemoveUserPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_UserRemovedPage ClickRemoveUserButtonInRemoveUserPage()
        {
            Continue();
            return new AS_UserRemovedPage(_context);
        }
    }
}
