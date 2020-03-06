using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class NotEligiblePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Your organisation is not eligible to apply to join RoATP";
        protected override By PageHeader => By.TagName("h2");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public NotEligiblePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage ReturnToApplicationOverview()
        {
            formCompletionHelper.ClickLinkByText("Application overview");
            return new ApplicationOverviewPage(_context);
        }
    }
}
