using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RecruitmentHomePage : BasePage
    {
        protected override string PageTitle => "Recruitment home";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        private By CreateANewVacancyButton => By.Id("new-vacancy-button");

        public RAA_RecruitmentHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_EmployerSelection CreateANewVacancy()
        {
            _formCompletionHelper.Click(CreateANewVacancyButton);
            return new RAA_EmployerSelection(_context);
        }
    }
}
