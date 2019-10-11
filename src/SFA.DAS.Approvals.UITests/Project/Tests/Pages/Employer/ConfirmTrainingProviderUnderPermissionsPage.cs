using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderUnderPermissionsPage : BasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By ChooseProviderOptions => By.CssSelector(".govuk-radios__label");
        private By ContinueButton => By.CssSelector(".govuk-button");


        public ConfirmTrainingProviderUnderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal TrainingProviderAddedPage ConfirmTrainingProvider()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChooseProviderOptions, "choice-1");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new TrainingProviderAddedPage(_context);
        }
    }
}

