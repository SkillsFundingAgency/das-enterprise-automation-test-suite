using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection
{
    public class FHABasePage : EPAO_BasePage
    {
        protected override string PageTitle => "Financial health assessment";
        private readonly ScenarioContext _context;

        #region Locators
        private By FHALink => By.LinkText("Financial health assessment");
        #endregion

        public FHABasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        //public  ClickFHALinkInFHABasePage()
        //{
        //    formCompletionHelper.Click(FHALink);
        //    return new (_context);
        //}
    }
}
