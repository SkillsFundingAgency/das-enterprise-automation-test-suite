using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class CloneVacancyDatesPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => _pageTitle;
        private string _pageTitle;

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CloneVacancyDatesPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            _pageTitle = $"Does the new {(isRaaV2Employer ? "advert" : "vacancy")} have the same closing date and start date?";
            VerifyPage();
        }

        public ConfimCloneVacancyDatePage SelectYes()
        {
            SelectRadioOptionByForAttribute("change-dates-yes");
            Continue();
            return new ConfimCloneVacancyDatePage(_context);
        }
    }
}
