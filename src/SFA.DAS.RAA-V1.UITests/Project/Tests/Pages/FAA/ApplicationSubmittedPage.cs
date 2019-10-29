using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public abstract class ApplicationSubmittedPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".bold-large");

        public ApplicationSubmittedPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }

}
