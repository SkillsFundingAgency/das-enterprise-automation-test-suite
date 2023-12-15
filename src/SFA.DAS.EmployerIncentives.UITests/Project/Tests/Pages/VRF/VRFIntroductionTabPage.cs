using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFIntroductionTabPage : VRFBasePage
    {
        protected override string PageTitle => "Provide organisation information about your banking and payments to DfE";

        #region Locators
        private static By VRFCookieCloseButton => By.Id("close-cookie-message");
        protected override By PageHeader => By.CssSelector("h1");
        #endregion

        public VRFIntroductionTabPage(ScenarioContext context) : base(context, false)
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(IFrameHelper.Iframe),
                () => { frameHelper.SwitchFrameAndAction(() => VerifyPage()); return true; }
            ]);
        }

        public VRFOrgDetailsTabPage ContinueToVRFOrgDetailsTab2Page()
        {
            if (pageInteractionHelper.IsElementPresent(VRFCookieCloseButton))
                formCompletionHelper.Click(VRFCookieCloseButton);

            frameHelper.SwitchFrameAndAction(() => Continue());
            return new VRFOrgDetailsTabPage(context);
        }
    }
}
