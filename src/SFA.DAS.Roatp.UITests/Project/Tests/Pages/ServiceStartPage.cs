using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ServiceStartPage : RoatpBasePage
    {
        protected override string PageTitle => "Apply to join the register of apprenticeship training providers";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApplyNow => By.LinkText("Apply now");

        public ServiceStartPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UsedThisServiceBeforePage ClickApplyNow()
        {
            formCompletionHelper.ClickElement(ApplyNow);
            return new UsedThisServiceBeforePage(_context);
        }
    }
}
