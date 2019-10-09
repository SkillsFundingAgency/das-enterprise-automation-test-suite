using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SearchForATrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Search for a training provider";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProviderPermissionsConfig _config;
        #endregion

        private By UKProviderReferenceNumberText => By.Id("Ukprn");
        private By ContinueButton => By.CssSelector(".govuk-button");

        public SearchForATrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ConfirmTrainingProviderUnderPermissionsPage SearchForATrainingProvider()
        {
            _formCompletionHelper.EnterText(UKProviderReferenceNumberText, _config.AP_ProviderPermissionUkprn);
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmTrainingProviderUnderPermissionsPage(_context);
        }
    }
}

