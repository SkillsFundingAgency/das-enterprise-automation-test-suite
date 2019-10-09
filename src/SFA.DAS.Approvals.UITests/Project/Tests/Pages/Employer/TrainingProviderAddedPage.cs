using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderAddedPage : BasePage
    {
        protected override string PageTitle => "Training provider added";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By SetPermissionsOptions => By.CssSelector(".govuk-radios__label");
        private By ContinueButton => By.CssSelector(".govuk-button");

        public TrainingProviderAddedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SetPermissionsPage SelectContinueInEmployerTrainingProviderAddedPage()
        {
            _formCompletionHelper.SelectRadioOptionByText(SetPermissionsOptions, "Set permissions for this training provider");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new SetPermissionsPage(_context);
        }
    }
}

