using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChangeApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "Change apprentice details";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private By DoYouWantToRequestChangesOptions => By.CssSelector(".selection-button-radio");
        private By FinishButton => By.ClassName("button");


        public ProviderChangeApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ProviderApprenticeDetailsPage ConfirmRequestToFixILRMismatch()
        {
            _formCompletionHelper.SelectRadioOptionByText(DoYouWantToRequestChangesOptions, "Yes, request this change");
            _formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(_context);
        }
    }
}