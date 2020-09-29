using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class FATV2IndexPage : FATV2BasePage
    {
        protected override string PageTitle => "Find apprenticeship training for your apprentice";
        private readonly ScenarioContext _context;

        #region Locators
        private By StartButton => By.LinkText("Start now");
        #endregion

        public FATV2IndexPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public FindApprenticeshipTrainingSearchPage ClickStartButton()
        {
            formCompletionHelper.Click(StartButton);
            return new FindApprenticeshipTrainingSearchPage(_context);
        }
    }
}
