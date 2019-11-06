using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal class ChoosingATrainingProviderPage : BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Constants
        private const string ExpectedChoosingATrainingProviderHeader = "CHOOSE A TRAINING PROVIDER";
        #endregion

        #region Page Objects Elements
        private readonly By _choosingATrainingProviderHeader = By.ClassName("heading-xl");
        #endregion

        public ChoosingATrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }
        public void CheckChoosingATrainingProviderTitle()
        {
          _pageInteractionHelper.VerifyText( _choosingATrainingProviderHeader, ExpectedChoosingATrainingProviderHeader);
        }
    }
}