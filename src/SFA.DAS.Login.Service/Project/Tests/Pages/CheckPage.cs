using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class CheckPage : VerifyBasePage
    {
        protected override string PageTitle { get; }

        protected abstract By Identifier { get; }

        public CheckPage(ScenarioContext context) : base(context) { }

        public bool IsPageDisplayed() => pageInteractionHelper.IsElementDisplayedAfterPageLoad(Identifier);
    }
}
