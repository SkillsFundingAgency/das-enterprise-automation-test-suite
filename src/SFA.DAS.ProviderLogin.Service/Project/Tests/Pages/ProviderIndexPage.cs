using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderIndexPage : IdamsLoginBasePage
	{
        protected override string PageTitle => "Manage apprenticeships on behalf of employers";

		private By StartNowButton => By.CssSelector(".button-start");

		public ProviderIndexPage(ScenarioContext context) : base(context) { }

        public ProviderSiginPage StartNow()
        {
			formCompletionHelper.ClickElement(StartNowButton);
			
			ClickIfPirenIsDisplayed();
			
			return new ProviderSiginPage(context);
		}
    }
}
