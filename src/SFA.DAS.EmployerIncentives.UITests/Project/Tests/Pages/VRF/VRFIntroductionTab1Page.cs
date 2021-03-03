using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFIntroductionTab1Page : VRFBasePage
    {
        protected override string PageTitle => "Provide organisation information about your banking and payments to DfE";

        protected override By PageHeader => By.CssSelector("h1");

        #region Locators
        private readonly ScenarioContext _context;
        private By VRFCookieCloseButton => By.Id("close-cookie-message");
        #endregion

        public VRFIntroductionTab1Page(ScenarioContext context) : base(context, false)
        { 
            _context = context;
            VerifyPage(frameHelper.Iframe);
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFOrgDetailsTab2Page ContinueToVRFOrgDetailsTab2Page()
        {
            if (pageInteractionHelper.IsElementPresent(VRFCookieCloseButton))
                formCompletionHelper.Click(VRFCookieCloseButton);

            frameHelper.SwitchFrameAndAction(() => Continue());
            return new VRFOrgDetailsTab2Page(_context);
        }
    }
}
