using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentHomePage : InterimBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly TableRowHelper _tableRowHelper;
        #endregion

        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruitment";

        private By Filter => By.CssSelector("#Filter");

        private By SearachInput => By.CssSelector("#search-input");

        private By SearchButton => By.CssSelector("#search-submit-button");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _tableRowHelper = context.Get<TableRowHelper>();
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
            formCompletionHelper.EnterText(SearachInput, objectContext.GetVacancyReference());
            formCompletionHelper.Click(SearchButton);
            pageInteractionHelper.WaitforURLToChange($"SearchTerm={objectContext.GetVacancyReference()}");
            _tableRowHelper.SelectRowFromTable("Manage", objectContext.GetVacancyReference());
            return new ManageVacancyPage(_context);
        }
    }
}
