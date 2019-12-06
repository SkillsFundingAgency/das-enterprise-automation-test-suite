using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithDrawConfirmationPage : BasePage
    {
        protected override string PageTitle => "Are you sure you want to withdraw your application?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion


        public FAA_WithDrawConfirmationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_WithdrawSuccessfulPage YesWithdraw()
        {
            _formCompletionHelper.SelectRadioOptionByText("Yes, withdraw");
            _formCompletionHelper.ClickButtonByText("Continue");
            return new FAA_WithdrawSuccessfulPage(_context);
        }
    } 
}
