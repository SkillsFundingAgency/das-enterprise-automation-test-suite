using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_HowWillYouCommunicateMarketExitToCustomersPage : EPAO_BasePage
    {
        protected override string PageTitle => "How will you communicate your market exit to customers?";
        private readonly ScenarioContext _context;
        #region Locators
        private By SupportInfoTextArea => By.XPath("//div[@class='govuk-character-count']//textarea[@id='WR-09']");
        #endregion
        public AS_HowWillYouCommunicateMarketExitToCustomersPage(ScenarioContext context) : base(context)
        {
            _context = context;
        //    VerifyPage();
        }
        public AS_WhenDoYouWantToWithdrawFromTheStandardPage EnterSupportingInformation()
        {
            formCompletionHelper.Click(SupportInfoTextArea);
            formCompletionHelper.EnterText(SupportInfoTextArea, standardDataHelper.GenerateRandomAlphanumericString(250));
            Continue();
            return new AS_WhenDoYouWantToWithdrawFromTheStandardPage(_context);
        }
    }
}