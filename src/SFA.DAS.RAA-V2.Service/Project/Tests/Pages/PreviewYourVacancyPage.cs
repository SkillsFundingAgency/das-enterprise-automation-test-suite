using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class PreviewYourVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Preview your vacancy";

        private By PreviewButton => By.CssSelector("[data-automation='link-continue']");
        
        #region Helpers and Context
        private readonly ScenarioContext _context;        
        #endregion

        public PreviewYourVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page PreviewVacancy()
        {
            formCompletionHelper.Click(PreviewButton);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
