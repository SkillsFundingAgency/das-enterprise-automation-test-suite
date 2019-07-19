using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class RenameAccountPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.XPath, Using = ".//*[@class=\"form-group\"]/dl/dd")] private IWebElement _currentNameLabel;
        [FindsBy(How = How.Id, Using = "NewName")] private IWebElement _newNameInput;
        [FindsBy(How = How.Id, Using = "accept")] private IWebElement _saveAndContinueButton;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Cancel\')]")] private IWebElement _cancelButton;
        private const string PageTitle = "Rename account";

        public RenameAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal string GetCurrentName()
        {
            return _currentNameLabel.Text;
        }

        internal RenameAccountPage SetNewName(string newName)
        {
            _formCompletionHelper.EnterText(_newNameInput, newName);
            return this;
        }

        internal void SaveAndContinue()
        {
            _formCompletionHelper.ClickElement(_saveAndContinueButton);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//ul//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}