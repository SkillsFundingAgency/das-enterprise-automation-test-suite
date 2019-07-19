using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class AboutYourSfaAgreementPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id=\"content\"]//h1[@class=\"heading-xlarge\"]")] private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = ".//input[@type=\"submit\"]")] private IWebElement _continueButton;

        public AboutYourSfaAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageHeader.Text.Contains("About your agreement");
        }

        public AcceptTheAgreementPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new AcceptTheAgreementPage(context);
        }
    }
}