using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideOrgInformationIntroductionPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "Provide organisation information about your banking and payments to DfE";

        protected override By PageHeader => By.CssSelector("h1");

        #region Locators
        private readonly ScenarioContext _context;
        private By VRFCookieCloseButton => By.Id("close-cookie-message");
        #endregion

        public ProvideOrgInformationIntroductionPage(ScenarioContext context) : base(context, false)
        { 
            _context = context;
            VerifyPage(frameHelper.Iframe);
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public ProvideOrgInformationOrgDetailsPage ContinueToOrgDetailsPage()
        {
            if (pageInteractionHelper.IsElementPresent(VRFCookieCloseButton))
                formCompletionHelper.Click(VRFCookieCloseButton);

            frameHelper.SwitchFrameAndAction(() => Continue());
            return new ProvideOrgInformationOrgDetailsPage(_context);
        }
    }
}
