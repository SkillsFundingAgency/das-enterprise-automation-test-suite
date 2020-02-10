
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmQualificationsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Qualifications";

        private By Preview => By.LinkText("Preview");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmQualificationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page ConfirmQualifications()
        {
            formCompletionHelper.Click(Preview);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
