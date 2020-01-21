using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_RemoveUserPage : EPAO_BasePage
    {
        protected override string PageTitle => "Remove user";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");
        private readonly ScenarioContext _context;

        #region Locators
        private By RemoveThisUserLink => By.LinkText("Remove this user");
        #endregion

        public AS_RemoveUserPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_UserRemovedPage ClickRemoveUserButtonInRemoveUserPage()
        {
            Continue();
            return new AS_UserRemovedPage(_context);
        }
    }
}
