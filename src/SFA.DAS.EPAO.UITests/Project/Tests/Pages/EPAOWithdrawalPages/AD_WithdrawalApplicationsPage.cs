using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalApplicationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal applications";

        private readonly ScenarioContext _context;

        private By NewWithdrawalApplication => By.XPath("//td[contains(text(),'Brewer (ST0580)')]/preceding-sibling::td[1]/a"); 
        public AD_WithdrawalApplicationsPage(ScenarioContext context) : base(context) => _context = context;
    
        public AD_StandardWithdrawalApplicationOverviewPage GoToStandardWithdrawlApplicationOverivewPage()
        {
            formCompletionHelper.ClickElement(NewWithdrawalApplication);
            return new AD_StandardWithdrawalApplicationOverviewPage(_context);
        }
    }
}
