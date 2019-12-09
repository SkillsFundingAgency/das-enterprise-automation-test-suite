using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentHomePage : InterimBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruitment";

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
        }

        public CreateVacancyPage CreateANewVacancy()
        {
            formCompletionHelper.ClickLinkByText("Create vacancy");
            return new CreateVacancyPage(_context);
        }
    }
}
