using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
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

        private By Filter => By.CssSelector("#Filter");

        private By SearchInput => By.CssSelector("#search-input");

        private By SearchButton => By.CssSelector("#search-submit-button");

        private By Manage => By.CssSelector("table tbody tr .govuk-link");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
        }

        public CreateVacancyPage CreateANewVacancy()
        {
            formCompletionHelper.ClickLinkByText("Create vacancy");
            return new CreateVacancyPage(_context);
        }

        public ManageVacancyPage SearchLiveVacancy()
        {
            formCompletionHelper.ClickLinkByText("Live vacancies");
            formCompletionHelper.SelectFromDropDownByValue(Filter, "Live");
            return SearchAnyVacancy();
        }

        public ManageVacancyPage SearchAnyVacancy()
        {
            var vacRef = objectContext.GetVacancyReference();
            formCompletionHelper.EnterText(SearchInput, vacRef);;
            formCompletionHelper.Click(SearchButton);
            pageInteractionHelper.WaitforURLToChange($"SearchTerm={vacRef}");
            formCompletionHelper.Click(Manage);
            return new ManageVacancyPage(_context);
        }
    }
}
