using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ShortDescriptionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Short description of the apprenticeship";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ShortDescription => By.Id("ShortDescription");
        
        public ShortDescriptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page EnterBriefOverview()
        {
            formCompletionHelper.EnterText(ShortDescription, rAAV2DataHelper.VacancyBriefOverview);
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
