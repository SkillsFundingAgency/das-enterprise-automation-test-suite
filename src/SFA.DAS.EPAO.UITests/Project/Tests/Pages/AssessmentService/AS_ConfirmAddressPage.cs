using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmAddressPage : BasePage
    {
        protected override string PageTitle => "Confirm the address where we are sending the certificate";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By ContinueButton => By.CssSelector(".govuk-button");
        #endregion

        public AS_ConfirmAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_RecipientNamePage ClickContinueInConfirmEmployerAddressPage()
        {
            _formCompletionHelper.Click(ContinueButton);
            return new AS_RecipientNamePage(_context);
        }
    }
}
