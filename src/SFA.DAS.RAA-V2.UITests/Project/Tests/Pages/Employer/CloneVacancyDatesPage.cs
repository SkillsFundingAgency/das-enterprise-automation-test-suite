using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class CloneVacancyDatesPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Does the new vacancy have the same closing date and start date?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CloneVacancyDatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ConfimCloneVacancyDatePage SelectYes()
        {
            SelectRadioOptionByForAttribute("change-dates-yes");
            Continue();
            return new ConfimCloneVacancyDatePage(_context);
        }
    }
}
