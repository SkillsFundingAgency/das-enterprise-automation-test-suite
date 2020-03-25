using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_WhatStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "What standard are you applying for?";

        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.CssSelector(".govuk-button[type='submit']");

        private By StandardName => By.CssSelector("#standard-name");

        public AS_WhatStandardPage(ScenarioContext context) : base(context) => _context = context;

        public AS_StandardSearchResultsPage EnterStandardName()
        {
            formCompletionHelper.EnterText(StandardName, dataHelper.ApplyforStandard);
            Continue();
            return new AS_StandardSearchResultsPage(_context);
        }
    }
}