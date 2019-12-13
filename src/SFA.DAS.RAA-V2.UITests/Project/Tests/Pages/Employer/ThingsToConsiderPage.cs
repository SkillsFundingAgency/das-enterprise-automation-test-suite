using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ThingsToConsiderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What else would you like the applicant to consider? (optional)";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ThingsToConsider => By.CssSelector("#ThingsToConsider");

        public ThingsToConsiderPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page EnterThingsToConsider()
        {
            _formCompletionHelper.EnterText(ThingsToConsider, _dataHelper.OptionalMessage);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
