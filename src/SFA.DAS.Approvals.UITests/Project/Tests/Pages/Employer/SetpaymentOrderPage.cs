using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SetpaymentOrderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Set payment order";

        public SetpaymentOrderPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
