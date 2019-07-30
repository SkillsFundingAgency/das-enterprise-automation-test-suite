using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class MyAccountWithOutPaye : BasePage
    {

        public MyAccountWithOutPaye(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        protected override string PageTitle => "MY ACCOUNT";

        protected override By PageHeader => By.CssSelector(".das-account__account-name");
    }
}