using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderIndexPage : IdamsLoginBasePage
	{
        protected override string PageTitle => EnvironmentConfig.IsTestEnvironment ? "Apprenticeship service for training providers: sign in or register for an account" : "Manage apprenticeships on behalf of employers";

        public ProviderIndexPage(ScenarioContext context) : base(context) { }

        public ProviderSiginPage StartNow()
        {
			formCompletionHelper.ClickElement(ProviderCSSSelectors.ProviderIndexStartSelector);
			
			ClickIfPirenIsDisplayed();
			
			return new ProviderSiginPage(context);
		}
    }
}
