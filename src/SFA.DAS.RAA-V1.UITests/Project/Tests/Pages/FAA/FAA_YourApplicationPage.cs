using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_YourApplicationPage : BasePage
    {
        protected override string PageTitle => "Your application";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public FAA_YourApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }


        public FAA_WithDrawConfirmation Withdraw()
        {
            _formCompletionHelper.ClickLinkByText("Withdraw my application");
            return new FAA_WithDrawConfirmation(_context);
        }

    }
}
