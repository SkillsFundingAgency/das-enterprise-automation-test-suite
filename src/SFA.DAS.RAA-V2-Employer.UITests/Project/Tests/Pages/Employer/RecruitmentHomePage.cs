using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentHomePage : InterimBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerDataHelper _dataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruitment";

        private By SearchInput => By.CssSelector("#search-input");

        private By SearchButton => By.CssSelector("#search-submit-button");

        private By Manage => By.CssSelector("table tbody tr .govuk-link");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAAV2EmployerDataHelper>();
        }

        public ManageVacancyPage SelectVacancy()
        {
            formCompletionHelper.ClickLinkByText("Live vacancies");
            pageInteractionHelper.WaitforURLToChange($"filter=Live");
            formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(Manage)));
            return new ManageVacancyPage(_context);
        }

        public CreateVacancyPage CreateANewVacancy()
        {
            formCompletionHelper.ClickLinkByText("Create vacancy");
            return new CreateVacancyPage(_context);
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
