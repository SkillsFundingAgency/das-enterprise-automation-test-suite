using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class LevleOfSupportProvidedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How do you agree with the apprentice what level of support is provided?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public LevleOfSupportProvidedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextRegardingHowDoYouAgreeForSupportProvidedAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.WhatLevelOfSupportProvided);
            return new ApplicationOverviewPage(_context);
        }
    }
}
