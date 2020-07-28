using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class CheckPage : LoginBasePage
    {
        protected override string PageTitle { get; }

        protected abstract By Identifier { get; }

        public CheckPage(ScenarioContext context) : base(context) { }

        public bool IsPageDisplayed() => pageInteractionHelper.IsElementDisplayed(Identifier);
    }
}
