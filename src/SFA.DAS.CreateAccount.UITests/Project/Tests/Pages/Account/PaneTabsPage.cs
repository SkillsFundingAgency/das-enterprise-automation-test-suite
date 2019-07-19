using System.Collections.Generic;
using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class PaneTabsPage : BasePage
    {
        protected const string tasksTabid = "tab-tasks";
        [FindsBy(How = How.Id, Using = tasksTabid)] protected IWebElement tasksTab;
        protected const string activitiesTabid = "tab-activity";
        [FindsBy(How = How.Id, Using = activitiesTabid)] protected IWebElement activityTab;
        private By _tasksListLinkText => By.CssSelector(".task-list a");
        private By _tasksListText => By.CssSelector(".task-list p");
        private By _acivityTab = By.XPath("//a[contains(text(),\'Activity\')]");
        private By _seeAllAcivityLink = By.XPath("//a[contains(text(),'See all activity')]");
        private By _activityPaneTabData = By.XPath("//div[@class=\'item-description\']");

        public PaneTabsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        private bool AreTasksPresented()
        {
            return pageInteractionHelper.IsElementDisplayed(tasksTab);
        }

        internal IEnumerable<string> ListofTasks()
        {
            var tasks = new List<string>();
            if (AreTasksPresented())
            {
                tasks.AddRange(WebBrowserDriver.FindElements(_tasksListLinkText).Select(x => x.Text));
                tasks.AddRange(WebBrowserDriver.FindElements(_tasksListText).Select(x => x.Text));
                return tasks;
            }
            return new List<string>();
        }

        internal AboutYourSfaAgreementPage OpenViewAgreementsLink()
        {
            var webelement = WebBrowserDriver.FindElements(_tasksListLinkText).Single(x => x.Text == "View agreements");
            _formCompletionHelper.ClickElement(webelement);
            return new AboutYourSfaAgreementPage(WebBrowserDriver);
        }

        public void ClickOnActivityTab()
        {
            _formCompletionHelper.ClickElement(WebBrowserDriver,_acivityTab);
        }

        public void ClickOnSeeAllActivityLink()
        {
            _formCompletionHelper.ClickElement(_seeAllAcivityLink);
        }

        public string GetActivityPaneTabText()
        {
            return pageInteractionHelper.GetTextFromElementsGroup(_activityPaneTabData);
        }

        public int GetActivitiesCount()
        {
            return pageInteractionHelper.GetCountOfElementsGroup(_activityPaneTabData);
        }

        public bool IsSeeAllActivityLinkPresent()
        {
            return _formCompletionHelper.IsElementDisplayed(_seeAllAcivityLink);
        }
    }
}