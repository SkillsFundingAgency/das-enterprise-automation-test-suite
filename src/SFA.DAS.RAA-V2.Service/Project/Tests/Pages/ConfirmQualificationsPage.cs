
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmQualificationsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Qualifications";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmQualificationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page ConfirmQualifications()
        {
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }

    }
}
