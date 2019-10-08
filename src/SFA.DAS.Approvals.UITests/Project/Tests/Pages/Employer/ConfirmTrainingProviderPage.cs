using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By ConfirmProviderDetailsOptions => By.CssSelector(".selection-button-radio");

        private By ContinueButton => By.Id("submit-select-provider");

        public ConfirmTrainingProviderPage(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmProviderDetailsOptions, "Confirmation-True");
            _formCompletionHelper.ClickElement(ContinueButton, true);
            return new StartAddingApprenticesPage(_context);
        }
    }
}