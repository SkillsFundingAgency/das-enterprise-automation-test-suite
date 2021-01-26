using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhatIsTheNewStartDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => "What is the start date with SOUTHAMPTON ENGINEERING TRAINING ASSOCIATION LIMITED (THE)?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NewStartMonthInput => By.Id("new-start-month");
        private By NewStartYearInput => By.Id("new-start-year");
        private By ContinueBtn => By.Id("continue-button");
        public WhatIsTheNewStartDatePage(ScenarioContext context) : base(context) => _context = context;

        public WhatIsTheNewStartDatePage EnterInvalidNewStartDate()
        {
            formCompletionHelper.EnterText(NewStartMonthInput, DateTime.Now.Month.ToString());
            formCompletionHelper.EnterText(NewStartYearInput, DateTime.Now.AddYears(-1).Year.ToString());
            formCompletionHelper.Click(ContinueBtn);

            return this;
        }

        public WhatIsTheNewEndDatePage EnterNewStartDate()
        {
            formCompletionHelper.EnterText(NewStartMonthInput, DateTime.Now.Month.ToString());
            formCompletionHelper.EnterText(NewStartYearInput, DateTime.Now.Year.ToString());
            formCompletionHelper.Click(ContinueBtn); 

            return new WhatIsTheNewEndDatePage(_context);
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterUpdatedNewStartDate()
        {
            formCompletionHelper.EnterText(NewStartMonthInput, DateTime.Now.AddMonths(1).Month.ToString());
            formCompletionHelper.EnterText(NewStartYearInput, DateTime.Now.AddMonths(1).Year.ToString());
            formCompletionHelper.Click(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(_context);
        }

    }
}
