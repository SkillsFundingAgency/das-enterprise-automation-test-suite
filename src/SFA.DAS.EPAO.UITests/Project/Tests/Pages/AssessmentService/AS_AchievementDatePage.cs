using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AchievementDatePage : BasePage
    {
        protected override string PageTitle => "What is the apprenticeship achievement date?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By DayTextBox => By.Id("Day");
        private By MonthTextBox => By.Id("Month");
        private By YearTextBox => By.Id("Year");
        private By ContinueButton => By.CssSelector(".govuk-button");
        #endregion

        public AS_AchievementDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();
            VerifyPage();
        }

        public AS_SearchEmployerAddress EnterAchievementDateAndContinue()
        {
            _formCompletionHelper.EnterText(DayTextBox, _randomDataGenerator.GetCurrentDay());
            _formCompletionHelper.EnterText(MonthTextBox, _randomDataGenerator.GetCurrentMonth());
            _formCompletionHelper.EnterText(YearTextBox, _randomDataGenerator.GetCurrentYear());
            _formCompletionHelper.Click(ContinueButton);
            return new AS_SearchEmployerAddress(_context);
        }
    }
}
