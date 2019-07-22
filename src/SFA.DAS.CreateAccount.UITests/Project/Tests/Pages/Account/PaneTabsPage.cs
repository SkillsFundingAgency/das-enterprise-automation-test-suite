using System.Collections.Generic;
using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class PaneTabsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected const string tasksTabid = "tab-tasks";
        protected By TasksTab => By.Id(tasksTabid);

        protected const string activitiesTabid = "tab-activity";
        [FindsBy(How = How.Id, Using = activitiesTabid)] protected IWebElement activityTab;
        private readonly By _tasksListLinkText = By.CssSelector(".task-list a");
        private readonly By _tasksListText = By.CssSelector(".task-list p");
        private readonly By _acivityTab = By.XPath("//a[contains(text(),\'Activity\')]");
        private readonly By _seeAllAcivityLink = By.XPath("//a[contains(text(),'See all activity')]");
        private readonly By _activityPaneTabData = By.XPath("//div[@class=\'item-description\']");

        private readonly IWebDriver _webDriver;

        public PaneTabsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        private bool AreTasksPresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(TasksTab);
        }

        internal IEnumerable<string> ListofTasks()
        {
            var tasks = new List<string>();
            if (AreTasksPresented())
            {
                tasks.AddRange(_webDriver.FindElements(_tasksListLinkText).Select(x => x.Text));
                tasks.AddRange(_webDriver.FindElements(_tasksListText).Select(x => x.Text));
                return tasks;
            }
            return new List<string>();
        }

        internal AboutYourSfaAgreementPage OpenViewAgreementsLink()
        {
            var webelement = _webDriver.FindElements(_tasksListLinkText).Single(x => x.Text == "View agreements");
            _formCompletionHelper.ClickElement(webelement);
            return new AboutYourSfaAgreementPage(_context);
        }

        public void ClickOnActivityTab()
        {
            _formCompletionHelper.ClickElement(_acivityTab);
        }

        public void ClickOnSeeAllActivityLink()
        {
            _formCompletionHelper.ClickElement(_seeAllAcivityLink);
        }

        public string GetActivityPaneTabText()
        {
            return _pageInteractionHelper.GetTextFromElementsGroup(_activityPaneTabData);
        }

        public int GetActivitiesCount()
        {
            return _pageInteractionHelper.GetCountOfElementsGroup(_activityPaneTabData);
        }

        public bool IsSeeAllActivityLinkPresent()
        {
            return _pageInteractionHelper.IsElementDisplayed(_seeAllAcivityLink);
        }
    }
}