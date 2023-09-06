using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class CheckStubSignInPage : CheckPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector(".govuk-input[id='Email']");

        public CheckStubSignInPage(ScenarioContext context) : base(context) { }
    }
}
