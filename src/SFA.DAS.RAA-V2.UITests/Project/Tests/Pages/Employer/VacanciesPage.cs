using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class VacanciesPage : BasePage
    {
        protected override string PageTitle => "Vacancies";

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;
        #endregion

        private By Filter => By.CssSelector("#Filter");

        public VacanciesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _vacancyTitleDatahelper = context.Get<VacancyTitleDatahelper>();
        }

        public ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage()
        {
            DraftVacancy();
            return new ApprenticeshipTrainingPage(_context);
        }

        public VacancyPreviewPart2Page GoToVacancyPreviewPart2Page()
        {
            DraftVacancy();
            return new VacancyPreviewPart2Page(_context);
        }

        private void DraftVacancy()
        {
            _formCompletionHelper.SelectFromDropDownByValue(Filter, "Draft");
            _pageInteractionHelper.WaitforURLToChange($"Filter=Draft");
            _tableRowHelper.SelectRowFromTable("Edit and submit", _vacancyTitleDatahelper.VacancyTitle);
        }

    }
}
