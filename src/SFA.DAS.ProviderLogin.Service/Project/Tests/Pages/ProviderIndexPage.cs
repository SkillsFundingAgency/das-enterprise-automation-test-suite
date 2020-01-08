using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderIndexPage : BasePage
    {
        protected override string PageTitle => "Manage apprenticeships on behalf of employers";
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By StartNowButton => By.CssSelector(".button-start");
		private By pireanPreprodButton = By.XPath("//span[contains(text(),'Pirean Preprod')]");

		public ProviderIndexPage(ScenarioContext context):base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderSiginPage StartNow()
        {
			_formCompletionHelper.ClickElement(StartNowButton);
			if (_pageInteractionHelper.IsElementDisplayed(pireanPreprodButton))
			{
				_formCompletionHelper.ClickElement(pireanPreprodButton);
			}
			return new ProviderSiginPage(_context);
		}
    }
}
