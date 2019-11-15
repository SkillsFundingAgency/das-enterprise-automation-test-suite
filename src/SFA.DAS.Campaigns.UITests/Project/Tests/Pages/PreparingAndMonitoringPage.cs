using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    internal class PreparingAndMonitoringPage :BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Constants
        private const string ExpectedPreparingAndMonitoringHeader = "PREPARING AND MONITORING";
        #endregion

        #region Page Objects Elements
        private readonly By _preparingAndMonitoringHeader = By.ClassName("heading-xl");
        #endregion


        public PreparingAndMonitoringPage(ScenarioContext context) :base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public void CheckPreparingAndMonitoringHeader()
        {
            _pageInteractionHelper.VerifyText(_preparingAndMonitoringHeader, ExpectedPreparingAndMonitoringHeader);
        }
    }
}