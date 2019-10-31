using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
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
        private readonly ObjectContext _objectContext;
        private readonly RAADataHelper _dataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By CreateANewVacancyButton => By.Id("new-vacancy-button");
        private By VacancySearchMode => By.CssSelector("#VacanciesSummary_VacanciesSummarySearch_SearchMode");
        private By VacancySearchText => By.CssSelector("#VacanciesSummary_VacanciesSummarySearch_SearchString");
        private By SearchVacancy => By.CssSelector("#search-vacancies-button");
        private By VacancyTitle => By.CssSelector(".vac-title");
        private By NoOfVacancy => By.CssSelector(".bold-xlarge");
        private By InlineText => By.CssSelector(".sfa-display-inline");

        public RAA_RecruitmentHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<RAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_EmployerSelection CreateANewVacancy()
        {
            formCompletionHelper.Click(CreateANewVacancyButton);
            return new RAA_EmployerSelection(_context);
        }

        public RAA_VacancySummaryPage SearchByReferenceNumber()
        {
            if (!_objectContext.IsApprenticeshipVacancyType())
            {
                formCompletionHelper.ClickLinkByText("Traineeships");
                _pageInteractionHelper.WaitForElementToChange(InlineText, "Your opportunities");
            }

            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "ReferenceNumber");
            formCompletionHelper.EnterText(VacancySearchText, _objectContext.GetVacancyReference());
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(SearchVacancy));
            _pageInteractionHelper.WaitForElementToChange(NoOfVacancy, "1");
            return GoToVacancSummary();
        }

        private RAA_VacancySummaryPage GoToVacancSummary()
        {
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLink(VacancyTitle, _dataHelper.VacancyTitle));
             return new RAA_VacancySummaryPage(_context);
        }
    }
}
