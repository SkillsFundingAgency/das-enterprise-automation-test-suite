using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class SkippyHomePage : BasePage
    {
        private const string PageTitle = "Your employer account";
        private By _addYourPAYELink = By.XPath("//a[contains(text(),'Add your PAYE scheme')]");

        public SkippyHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public void ClickOnAddYourPAYESchemeLink()
        {
            _formCompletionHelper.ClickElement(_addYourPAYELink);
        }
    }
}