using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewChangesPage : BasePage
    {
        protected override string PageTitle => "Review changes";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsDataHelper _dataHelper;
        #endregion

        private By ConfirmChangesOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");


        public ProviderReviewChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        
        public ProviderEditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            SelectConfirmChangesOptions("changes-approved-true")
            .Continue();
            return new ProviderEditedApprenticeDetailsPage(_context);
        }

        public ProviderApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            SelectConfirmChangesOptions("changes-approved-false")
            .Continue();
            return new ProviderApprenticeDetailsPage(_context);
        }

        private ProviderReviewChangesPage SelectConfirmChangesOptions(string option)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, option);
            return this;
        }

        private void Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}
