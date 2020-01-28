using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public class AP_OrganisationDetailsBasePage : EPAO_BasePage
    {
        protected override string PageTitle => "Organisation details";
        private readonly ScenarioContext _context;

        #region Locators
        private By TradingNameLink => By.LinkText("Trading name");
        #endregion

        public AP_OrganisationDetailsBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_ApplicationOverviewPage ClickReturnToApplicationOverviewButton()
        {
            Continue();
            return new AP_ApplicationOverviewPage(_context);
        }

        public AP_OD1_TradingNamePage ClickTradingNameLinkInOrganisationDetailsPage()
        {
            formCompletionHelper.Click(TradingNameLink);
            return new AP_OD1_TradingNamePage(_context);
        }
    }
}
