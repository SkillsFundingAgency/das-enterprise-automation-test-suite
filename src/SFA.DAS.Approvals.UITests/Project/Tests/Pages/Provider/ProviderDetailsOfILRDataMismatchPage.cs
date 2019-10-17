using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDetailsOfILRDataMismatchPage : BasePage
    {
        protected override string PageTitle => "Details of ILR data mismatch";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private By FixILRMismatchOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.Id("fix-mismatch");

        public ProviderDetailsOfILRDataMismatchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }


        internal ProviderChangeApprenticeDetailsPage RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-Confirm");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderChangeApprenticeDetailsPage(_context);
        }
    }
}
