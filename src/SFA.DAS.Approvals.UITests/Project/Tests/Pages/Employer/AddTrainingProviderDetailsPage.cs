using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingProviderDetailsPage : BasePage
    {
        protected override string PageTitle => "Add training provider details";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private By ukprnField => By.CssSelector(".govuk-input");

        private By continueButton => By.CssSelector(".govuk-button");

        public AddTrainingProviderDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            return Continue();
        }

        private AddTrainingProviderDetailsPage EnterUkprn()
        {
            _formCompletionHelper.EnterText(ukprnField, _config.AP_ProviderUkprn);
            return this;
        }

        private ConfirmTrainingProviderPage Continue()
        {
            _formCompletionHelper.ClickElement(continueButton);
            return new ConfirmTrainingProviderPage(_context);
        }
    }
}