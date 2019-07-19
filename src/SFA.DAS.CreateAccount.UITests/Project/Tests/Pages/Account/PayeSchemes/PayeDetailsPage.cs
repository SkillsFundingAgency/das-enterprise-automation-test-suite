using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes
{
    public class PayeDetailsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \"Remove PAYE scheme\")]")] private IWebElement _removeSchemeButton;
        [FindsBy(How = How.XPath, Using = ".//*[@id=\"confirm\"]//label[1]")] private IWebElement _confirmRemovingRadioButton;
        [FindsBy(How = How.XPath, Using = ".//*[@id=\"confirm\"]//label[2]")] private IWebElement _discardRemovindRadioButton;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement _continueButton;

        public PayeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal PayeDetailsPage ClickOnRemoveScheme()
        {
            _formCompletionHelper.ClickElement(_removeSchemeButton);
            return this;
        }

        internal PayeSchemePage ConfirmRemoving()
        {
            _formCompletionHelper.SelectRadioButton(_confirmRemovingRadioButton);
            _formCompletionHelper.ClickElement(_continueButton);
            return new PayeSchemePage(_context);
        }

        internal PayeSchemePage DiscardRemoving()
        {
            _formCompletionHelper.SelectRadioButton(_discardRemovindRadioButton);
            _formCompletionHelper.ClickElement(_continueButton);
            return new PayeSchemePage(_context);
        }
    }
}