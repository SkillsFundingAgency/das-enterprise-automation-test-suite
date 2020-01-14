using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Vacancies";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");

        public ViewAllVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SelectEmployersPage CreateVacancy()
        {
            _formCompletionHelper.Click(CreateVacancyLink);
            return new SelectEmployersPage(_context);
        }
    }
}
