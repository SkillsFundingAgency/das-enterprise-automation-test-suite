using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class MyAccountWithOutPaye : BasePage
    {
        protected override string PageTitle => "MY ACCOUNT";

        public MyAccountWithOutPaye(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}