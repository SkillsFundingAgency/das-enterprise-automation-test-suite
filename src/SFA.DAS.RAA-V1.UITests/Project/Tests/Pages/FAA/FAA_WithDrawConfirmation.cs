using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_WithDrawConfirmation : BasePage
    {
        protected override string PageTitle => "Are you sure you want to withdraw your application?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion


        public FAA_WithDrawConfirmation(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_WithdrawSuccessful YesWithdraw()
        {
            _formCompletionHelper.SelectRadioOptionByText("Yes, withdraw");
            return new FAA_WithdrawSuccessful(_context);
        }
    } 
}
