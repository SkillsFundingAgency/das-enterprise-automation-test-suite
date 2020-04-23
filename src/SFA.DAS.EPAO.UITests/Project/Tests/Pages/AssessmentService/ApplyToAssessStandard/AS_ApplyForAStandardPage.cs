using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ApplyForAStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apply for a standard";
        private readonly ScenarioContext _context;

        private By StartButton => By.CssSelector("#main-content .govuk-button");

        public AS_ApplyForAStandardPage(ScenarioContext context) : base(context) => _context = context;

        public AS_WhatStandardPage Start()
        {
            formCompletionHelper.ClickElement(StartButton);
            return new AS_WhatStandardPage(_context);
        }
    }
}
