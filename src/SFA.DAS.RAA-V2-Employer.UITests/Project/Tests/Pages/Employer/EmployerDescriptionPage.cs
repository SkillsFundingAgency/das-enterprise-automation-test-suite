using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{

    public class EmployerDescriptionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Add some information";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        private By EmployerDescription => By.CssSelector("#EmployerDescription");

        private By EmployerWebsiteUrl => By.CssSelector("#EmployerWebsiteUrl");

        public EmployerDescriptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
        public VacancyPreviewPart2Page EnterEmployerDescription()
        {
            formCompletionHelper.EnterText(EmployerDescription, dataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerWebsiteUrl, dataHelper.EmployerWebsiteUrl);
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
