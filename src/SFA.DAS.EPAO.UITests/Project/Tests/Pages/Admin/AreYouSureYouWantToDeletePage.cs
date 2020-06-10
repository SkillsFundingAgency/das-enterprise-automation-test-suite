using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AreYouSureYouWantToDeletePage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Are you sure you want to delete";

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AreYouSureYouWantToDeletePage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public AuditDetailsPage ClickYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new AuditDetailsPage(_context);
        }
    }
}