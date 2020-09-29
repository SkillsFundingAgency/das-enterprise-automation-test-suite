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
        #endregion

        public ProvideOrgInformationIntroductionPage(ScenarioContext context) : base(context, false)
        { 
            _context = context;
            VerifyPage(frameHelper.Iframe);
            frameHelper.SwitchToFrame();
            VerifyPage();
            frameHelper.SwitchToDefaultContent();
        }

        public ProvideOrgInformationOrgDetailsPage ContinueToOrgDetailsPage()
        {
            formCompletionHelper.ClickButtonByText("Continue");
            return new ProvideOrgInformationOrgDetailsPage(_context);
        }
    }
}
