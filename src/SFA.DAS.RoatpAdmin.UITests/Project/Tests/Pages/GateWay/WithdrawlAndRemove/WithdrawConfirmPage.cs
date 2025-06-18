using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.WithdrawlAndRemove
{
    public class WithdrawConfirmPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to withdraw this application?";

        private static By InternalComments => By.Id("OptionYesText");

        public WithdrawConfirmPage(ScenarioContext context) : base(context) => VerifyPage();

        public WithDrawOutcomePage YesSureWithdrawThisApplication()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(InternalComments, "Withdraw Application Comments");
            Continue();
            return new WithDrawOutcomePage(context);
        }
    }
}
