using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class MostExperiencedEmployeePage : RoatpBasePage
    {
        protected override string PageTitle => "Who's the most experienced employee";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        protected By LabelCssSelector => By.CssSelector(".govuk-form-group");

        public MostExperiencedEmployeePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ExperienceInTheSectorPage EnterDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Full name", applydataHelpers.FullName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Job role", applydataHelpers.JobRole);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Time in role", $"{applydataHelpers.GenerateRandomWholeNumber(1)} years, {applydataHelpers.GenerateRandomWholeNumber(1)} months");
            Continue();
            return new ExperienceInTheSectorPage(_context);
        }
    }
}


