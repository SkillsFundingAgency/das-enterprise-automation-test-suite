using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class FindEPAOIndexPage : FindEPAOBasePage
    {
        protected override string PageTitle => "Find an end-point assessment organisation for your apprentice";

        #region Locators
        private By StartButton => By.LinkText("Start now");
        #endregion

        public FindEPAOIndexPage(ScenarioContext context) : base(context) { }

        public SearchApprenticeshipTrainingCoursePage ClickStartButton()
        {
            formCompletionHelper.Click(StartButton);
            return new SearchApprenticeshipTrainingCoursePage(context);
        }
    }
}
