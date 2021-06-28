using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class FindEPAOIndexPage : FindEPAOBasePage
    {
        protected override string PageTitle => "Find an end-point assessment organisation for your apprentice";
        private readonly ScenarioContext _context;

        #region Locators
        private By StartButton => By.LinkText("Start now");
        #endregion

        public FindEPAOIndexPage(ScenarioContext context) : base(context) => _context = context;

        public SearchApprenticeshipTrainingCoursePage ClickStartButton()
        {
            formCompletionHelper.Click(StartButton);
            return new SearchApprenticeshipTrainingCoursePage(_context);
        }
    }
}
