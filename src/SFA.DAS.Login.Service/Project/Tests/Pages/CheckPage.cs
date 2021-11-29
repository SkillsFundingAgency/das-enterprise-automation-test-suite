using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class CheckPage : BasePage
    {
        protected override string PageTitle { get; }

        protected abstract By Identifier { get; }

        public CheckPage(ScenarioContext context) : base(context) { }

        public bool IsPageDisplayed() => pageInteractionHelper.IsElementDisplayed(Identifier);
    }
}
