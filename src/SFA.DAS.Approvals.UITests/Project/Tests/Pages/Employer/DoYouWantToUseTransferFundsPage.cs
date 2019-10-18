using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class DoYouWantToUseTransferFundsPage : BasePage
    {
        protected override string PageTitle => "Do you want to use transfer funds to pay for this training?";
        private By CohortFundingOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.Id("submit-transfer-connection");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion


        public DoYouWantToUseTransferFundsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal AddTrainingProviderDetailsPage SelectYesIWantToUseTransferFunds()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortFundingOptions, "TransferConnection-GBGMDB");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new AddTrainingProviderDetailsPage(_context);
        }

    }
}

