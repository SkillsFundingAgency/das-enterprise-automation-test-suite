using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class AgreementNotSignedPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Continue anyway\')]")] private IWebElement _continueAnywayButton;

        public AgreementNotSignedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public AddTrainingProvidersDetailsPage ContinueAnyway()
        {
            _formCompletionHelper.ClickElement(_continueAnywayButton);
            return new AddTrainingProvidersDetailsPage(context);
        }
    }
}