using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ConfirmAccountDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm account deletion";

        private By DeleteAccountButton => By.Id("DeleteAccountAction");

        #region Helpers and Context
        private readonly PageInteractionHelper _PageInteractionhelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public FAA_ConfirmAccountDeletionPage(ScenarioContext context): base(context)
        {
            _context = context;
            _PageInteractionhelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_SignInPage DeleteAccount()
        {
            _formCompletionHelper.Click(DeleteAccountButton);
            return new FAA_SignInPage(_context);
        }
    }
}
