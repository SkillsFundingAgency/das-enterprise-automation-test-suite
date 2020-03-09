using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public class ServiceStartPage : BasePage
    {
        protected override string PageTitle => "ESFA admin services";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By StartNow => By.CssSelector(".govuk-button--start");

        public ServiceStartPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public IdamsPage ClickStartNow()
        {
            _formCompletionHelper.ClickElement(StartNow);
            return new IdamsPage(_context);
        }
    }
}
