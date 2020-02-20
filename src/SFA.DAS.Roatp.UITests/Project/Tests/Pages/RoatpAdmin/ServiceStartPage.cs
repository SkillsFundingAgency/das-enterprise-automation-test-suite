using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ServiceStartPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "ESFA admin services";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StartNow => By.CssSelector(".govuk-button--start");

        public ServiceStartPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public IdamsPage ClickStartNow()
        {
            formCompletionHelper.ClickElement(StartNow);
            return new IdamsPage(_context);
        }
    }
}
