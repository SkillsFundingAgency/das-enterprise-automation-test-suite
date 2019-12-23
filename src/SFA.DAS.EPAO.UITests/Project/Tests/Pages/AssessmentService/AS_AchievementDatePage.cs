using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AchievementDatePage : BasePage
    {
        protected override string PageTitle => "What is the apprenticeship achievement date?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EPAODataHelper _ePAODataHelper;
        #endregion

        #region Locators
        private By DayTextBox => By.Id("Day");
        private By MonthTextBox => By.Id("Month");
        private By YearTextBox => By.Id("Year");
        #endregion

        public AS_AchievementDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAODataHelper = new EPAODataHelper(_context);
            VerifyPage();
        }

        public AS_SearchEmployerAddress EnterAchievementDateAndContinue()
        {
            _ePAODataHelper.EnterDate(DayTextBox, DateTime.Now.Day);
            _ePAODataHelper.EnterDate(MonthTextBox, DateTime.Now.Month);
            _ePAODataHelper.EnterDate(YearTextBox, DateTime.Now.Year);
            Continue();
            return new AS_SearchEmployerAddress(_context);
        }
    }
}
