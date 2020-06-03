using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SetpaymentOrderPage : BasePage
    {
        protected override string PageTitle => "Set payment order";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SetpaymentOrderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
