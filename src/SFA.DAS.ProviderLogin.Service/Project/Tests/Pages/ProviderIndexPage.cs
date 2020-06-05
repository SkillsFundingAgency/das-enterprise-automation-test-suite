using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderIndexPage : ProviderLoginBasePage
    {
        protected override string PageTitle => "Manage apprenticeships on behalf of employers";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StartNowButton => By.CssSelector(".button-start");
		private By PireanPreprodButton => By.XPath("//span[contains(text(),'Pirean Preprod')]");

		public ProviderIndexPage(ScenarioContext context):base(context) => _context = context;

        public ProviderSiginPage StartNow()
        {
			formCompletionHelper.ClickElement(StartNowButton);
			if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
			{
				formCompletionHelper.ClickElement(PireanPreprodButton);
			}
			return new ProviderSiginPage(_context);
		}
    }
}
