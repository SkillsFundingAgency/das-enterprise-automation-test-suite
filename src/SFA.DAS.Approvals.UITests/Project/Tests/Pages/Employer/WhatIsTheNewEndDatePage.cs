using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhatIsTheNewEndDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => $"What is the new planned training end date with {changeOfPartyConfig.NewProviderName}?";

        protected override string AccessibilityPageTitle => "What is the new planned training end date with new provider";

        private static By NewEndMonthInput => By.CssSelector(".govuk-input--width-2");
        private static By NewEndYearInput => By.CssSelector(".govuk-input--width-4");
        private static By ContinueBtn => By.XPath("//button[@class='govuk-button']");
        public WhatIsTheNewEndDatePage(ScenarioContext context) : base(context) { }

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

            return new WhatIsTheNewPricePage(context);
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterUpdatedNewEndDate()
        {
            formCompletionHelper.EnterText(NewEndMonthInput, DateTime.Now.Month.ToString());
            formCompletionHelper.EnterText(NewEndYearInput, DateTime.Now.AddYears(2).AddMonths(1).Year.ToString());
            formCompletionHelper.ClickElement(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(context);
        }
    }
}
