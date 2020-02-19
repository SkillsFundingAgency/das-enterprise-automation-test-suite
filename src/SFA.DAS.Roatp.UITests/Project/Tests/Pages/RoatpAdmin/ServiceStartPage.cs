using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ServiceStartPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Register of apprenticeship training providers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StartNow => By.CssSelector(".govuk-button--start");

        public ServiceStartPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void ClickStartNow()
        {
            formCompletionHelper.ClickElement(StartNow);
        }
    }
}
