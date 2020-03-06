using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ASK.UITests.Project.Tests.Pages
{
    public class DoYouHaveDFEAccountPage : AskBasePage
    {
        protected override string PageTitle => "Do you have a DfE Sign-in account?";

        protected override By PageHeader => By.CssSelector("h1.govuk-fieldset__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouHaveDFEAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
