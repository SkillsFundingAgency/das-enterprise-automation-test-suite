using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightLandingPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "RoATP application outcomes";
        protected override By OutcomeTab => By.CssSelector("a[href='#outcomes']");
        protected override By OutcomeStatus => By.CssSelector("[data-label='Overall outcome']");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OversightLandingPage(ScenarioContext context) : base(context) => _context = context;

        public new OversightLandingPage VerifyOutcomeStatus(string expectedStatus)
        {
            base.VerifyOutcomeStatus(expectedStatus);
            return this;
        }

        public ApplicationSummaryPage SelectApplication()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ApplicationSummaryPage(_context);
        }
    }
}
