using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class AddTrainingProvidersDetailsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "ProviderId")] private IWebElement _providerIdInput;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public AddTrainingProvidersDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public AddTrainingProvidersDetailsPage SetProviderId(string id)
        {
            _formCompletionHelper.EnterText(_providerIdInput, id);
            return this;
        }

        public ConfirmTrainingProviderPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new ConfirmTrainingProviderPage(_context);
        }
    }
}