using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class FATIndexPage : FATBasePage
    {
        protected override string PageTitle => "Find apprenticeship training";
        private readonly ScenarioContext _context;

        #region Locators
        private By StartButton => By.Id("start-button");
        #endregion

        public FATIndexPage(ScenarioContext context) : base(context)
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
