using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhatIsTheNewStartDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => $"What is the start date with {changeOfPartyConfig.NewProviderName}?";

        protected override string AccessibilityPageTitle => "What is the start date with new provider";

        private static By NewStartMonthInput => By.Id("new-start-month");
        private static By NewStartYearInput => By.Id("new-start-year");
        private static By ContinueBtn => By.Id("continue-button");

        public WhatIsTheNewStartDatePage(ScenarioContext context) : base(context)  { }

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

            return new WhatIsTheNewEndDatePage(context);
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterUpdatedNewStartDate()
        {
            formCompletionHelper.EnterText(NewStartMonthInput, DateTime.Now.AddMonths(1).Month.ToString());
            formCompletionHelper.EnterText(NewStartYearInput, DateTime.Now.AddMonths(1).Year.ToString());
            formCompletionHelper.Click(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(context);
        }

    }
}
