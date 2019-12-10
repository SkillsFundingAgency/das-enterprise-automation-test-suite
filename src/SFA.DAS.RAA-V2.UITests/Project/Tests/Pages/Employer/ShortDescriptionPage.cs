using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
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
            VerifyPage();
        }

        public VacancyPreviewPart2Page EnterBriefOverview()
        {
            _formCompletionHelper.EnterText(ShortDescription, _dataHelper.VacancyBriefOverview);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
