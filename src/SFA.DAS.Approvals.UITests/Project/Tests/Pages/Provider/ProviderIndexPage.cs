using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{

    public class ProviderIndexPage : BasePage
    {
        protected override string PageTitle => "Manage apprenticeships on behalf of employers";
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By StartNowButton => By.CssSelector(".button-start");

        public ProviderIndexPage(ScenarioContext context):base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderSiginPage StartNow()
        {
            _formCompletionHelper.ClickElement(StartNowButton);
            return new ProviderSiginPage(_context);
        }
    }
}
