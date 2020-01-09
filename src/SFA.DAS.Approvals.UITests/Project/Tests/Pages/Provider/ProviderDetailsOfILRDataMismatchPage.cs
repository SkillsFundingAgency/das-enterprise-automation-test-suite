using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDetailsOfILRDataMismatchPage : BasePage
    {
        protected override string PageTitle => "Details of ILR data mismatch";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By FixILRMismatchOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.Id("fix-mismatch");

        public ProviderDetailsOfILRDataMismatchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ProviderChangeApprenticeDetailsPage RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-Confirm");
            Continue();
            return new ProviderChangeApprenticeDetailsPage(_context);
        }
    }
}
