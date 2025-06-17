using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.WithdrawlAndRemove
{
    public class RemoveConfirmPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to remove this application?";

        private static By InternalComments => By.Id("OptionYesText");
        private static By ExternalComments => By.Id("OptionYesTextExternal");

        public RemoveConfirmPage(ScenarioContext context) : base(context) => VerifyPage();

        public RemoveOutcomePage YesSureRemoveThisApplication()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(InternalComments, "Withdraw Application Internal Comments");
            formCompletionHelper.EnterText(ExternalComments, "Withdraw Application External Comments");
            Continue();
            return new RemoveOutcomePage(context);
        }
    }
}
