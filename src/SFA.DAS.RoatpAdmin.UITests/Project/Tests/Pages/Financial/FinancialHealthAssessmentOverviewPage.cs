using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssessmentOverviewPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Financial health assessment overview";

        private By DayOutStandingField => By.Id("OutstandingFinancialDueDate.Day");
        private By MonthOutStandingField => By.Id("OutstandingFinancialDueDate.Month");
        private By YearOutStandingField => By.Id("OutstandingFinancialDueDate.Year");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialHealthAssessmentOverviewPage(ScenarioContext context) : base(context)
        {
           _context = context;
           VerifyPage();
        }

        public FinancialHealthAssesmentCompletedPage SelectingNewApplication()
        {
            formCompletionHelper.SelectRadioOptionByText("Outstanding");
            formCompletionHelper.EnterText(DayOutStandingField, "1");
            formCompletionHelper.EnterText(MonthOutStandingField, "2");
            formCompletionHelper.EnterText(YearOutStandingField, "2022");
            formCompletionHelper.ClickButtonByText("Save outcome");
            return new FinancialHealthAssesmentCompletedPage(_context);
        }

    }
}