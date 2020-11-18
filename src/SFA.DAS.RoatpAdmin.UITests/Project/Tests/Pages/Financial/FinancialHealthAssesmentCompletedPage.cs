using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssesmentCompletedPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Financial health assessment completed";
        private By GoToRoATPFinancialApplicationsLink => By.LinkText("Back to RoATP financial applications");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialHealthAssesmentCompletedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public FinancialHealthAssessmentOverviewPage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPFinancialApplicationsLink);
            return new FinancialHealthAssessmentOverviewPage(_context);
        }
    }
}
