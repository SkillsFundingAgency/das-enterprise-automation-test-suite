using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes
{
    public class PayeDetailsPage : BasePage
    {
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
            return new PayeSchemePage(context);
        }

        internal PayeSchemePage DiscardRemoving()
        {
            _formCompletionHelper.SelectRadioButton(_discardRemovindRadioButton);
            _formCompletionHelper.ClickElement(_continueButton);
            return new PayeSchemePage(context);
        }
    }
}