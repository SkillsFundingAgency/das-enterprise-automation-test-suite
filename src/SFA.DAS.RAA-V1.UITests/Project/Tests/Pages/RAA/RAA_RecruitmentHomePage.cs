using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RecruitmentHomePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Recruitment home";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CreateANewVacancyButton => By.Id("new-vacancy-button");


        public RAA_RecruitmentHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_EmployerSelection CreateANewVacancy()
        {
            formCompletionHelper.Click(CreateANewVacancyButton);
            return new RAA_EmployerSelection(_context);
        }
    }
}
