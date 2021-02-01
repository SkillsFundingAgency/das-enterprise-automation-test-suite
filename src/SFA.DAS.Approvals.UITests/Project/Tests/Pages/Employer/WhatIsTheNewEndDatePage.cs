using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhatIsTheNewEndDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => $"What is the new planned training end date with {changeOfPartyConfig.NewProviderName}?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NewEndMonthInput => By.CssSelector(".govuk-input--width-2");
        private By NewEndYearInput => By.CssSelector(".govuk-input--width-4");
        private By ContinueBtn => By.XPath("//button[@class='govuk-button']");
        public WhatIsTheNewEndDatePage(ScenarioContext context) : base(context) => _context = context;

        public WhatIsTheNewEndDatePage EnterInvalidEndDate()
        {
            formCompletionHelper.Click(ContinueBtn);

            return this;
        }

        public WhatIsTheNewPricePage EnterNewEndDate()
        {
            formCompletionHelper.EnterText(NewEndMonthInput, DateTime.Now.Month.ToString());
            formCompletionHelper.EnterText(NewEndYearInput, DateTime.Now.AddYears(2).Year.ToString());
            formCompletionHelper.Click(ContinueBtn);

            return new WhatIsTheNewPricePage(_context);
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterUpdatedNewEndDate()
        {
            formCompletionHelper.EnterText(NewEndMonthInput, DateTime.Now.Month.ToString());
            formCompletionHelper.EnterText(NewEndYearInput, DateTime.Now.AddYears(2).AddMonths(1).Year.ToString());
            formCompletionHelper.ClickElement(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(_context);
        }
    }
}
