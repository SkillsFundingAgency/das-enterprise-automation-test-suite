using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
   public class ApprovedStandardsAndVersionsLandingPage : EPAO_BasePage
    {
        protected override string PageTitle => "Approved standards and versions";

        private readonly ScenarioContext _context;

        #region Locators
        private By AssociateProjectManagerLink => By.CssSelector("a[href='/standard/view-standard/ST0310']");
        #endregion

        public ApprovedStandardsAndVersionsLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public StandardDetailsForAssociateProjectManagerPage ClickOnAssociateProjectManagerLink()
        {
            formCompletionHelper.ClickElement(AssociateProjectManagerLink);
            return new StandardDetailsForAssociateProjectManagerPage(_context);
        }
    }
}