using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAA_ApplicationSubmittedPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".bold-large");

        public FAA_ApplicationSubmittedPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }

}
