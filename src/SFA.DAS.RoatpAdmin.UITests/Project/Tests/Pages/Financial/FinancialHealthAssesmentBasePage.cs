using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssesmentBasePage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Financial health assessment overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialHealthAssesmentBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinancialHealthAssessmentOverviewPage VerifyApplicationStatus(By statusSelector, string expectedStatus, Action action)
        {
            var linkText = objectContext.GetProviderName();

            action.Invoke();

            VerifyElement(() => tableRowHelper.GetColumn(linkText, statusSelector), expectedStatus, action);

            return new FinancialHealthAssessmentOverviewPage(_context);
        }
    }
}
