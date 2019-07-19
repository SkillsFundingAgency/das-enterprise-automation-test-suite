using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class ChooseTrainingOrgPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//fieldset//label[1]")] private IWebElement _firstOrganizationButton;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public ChooseTrainingOrgPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public ChooseTrainingOrgPage PickFirstOrganization()
        {
            formCompletionHelper.SelectRadioButton(_firstOrganizationButton);
            return this;
        }

        public AgreementNotSignedPage Continue()
        {
            formCompletionHelper.ClickElement(_continueButton);
            return new AgreementNotSignedPage(WebBrowserDriver);
        }
    }
}