using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAA_ApplicationSubmittedPage : FAABasePage
    {
        protected override By PageHeader => By.CssSelector(".bold-large");

        public FAA_ApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    }
}
