using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class SignedOutPage : EPAOAdmin_BasePage
    {
        protected override By PageHeader => By.CssSelector("#mainContent");

        protected override string PageTitle => "You have been logged out from the application successfully";

        public SignedOutPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
