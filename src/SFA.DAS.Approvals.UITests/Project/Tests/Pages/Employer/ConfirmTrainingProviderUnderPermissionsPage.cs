using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderUnderPermissionsPage : BasePage
    {
        protected override string PageTitle => "Add training provider details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By ChooseProviderOptions => By.CssSelector(".govuk-radios__label");

        public ConfirmTrainingProviderUnderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal TrainingProviderAddedPage ConfirmTrainingProvider()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChooseProviderOptions, "choice-1");
            Continue();
            return new TrainingProviderAddedPage(_context);
        }
    }
}

