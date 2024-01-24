using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class SearchVacancyPageHelper(ScenarioContext context)
    {

        #region Helpers and Context
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly PageInteractionHelper _pageInteractionHelper = context.Get<PageInteractionHelper>();
        private readonly FormCompletionHelper _formCompletionHelper = context.Get<FormCompletionHelper>();
        #endregion

        private static By SearchInput => By.CssSelector("#search-input");

        private static By SearchButton => By.CssSelector(".govuk-button.das-search-form__button");

        private static By Manage => By.CssSelector("[data-label='Action']");

        public ManageRecruitPage SelectLiveVacancy()
        {
            _formCompletionHelper.ClickLinkByText("Live adverts");
            _pageInteractionHelper.WaitforURLToChange($"filter=Live");
            _formCompletionHelper.ClickElement(RandomDataGenerator.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(Manage)));
            return new ManageRecruitPage(context);
        }

        public ProviderVacancySearchResultPage SearchVacancyByVacancyReference()
        {
            SearchVacancy();
            return new ProviderVacancySearchResultPage(context);
        }

        public ProviderVacancySearchResultPage SearchProviderVacancy()
        {
            SearchEmployerProviderPermissionVacancy();
            return new ProviderVacancySearchResultPage(context);
        }

        public VacancyCompletedAllSectionsPage SearchReferVacancy()
        {
            SearchVacancy();
            return new VacancyCompletedAllSectionsPage(context);
        }

        public EmployerVacancySearchResultPage SearchEmployerVacancy()
        {
            SearchEmployerProviderPermissionVacancy();
            return new EmployerVacancySearchResultPage(context);
        }
        public EmployerVacancySearchResultPage SearchEmployerVacancyByVacancyReference()
        {
            SearchVacancy();
            return new EmployerVacancySearchResultPage(context);
        }

        internal void SearchEmployerProviderPermissionVacancy() => SearchVacancy();

        private void SearchVacancy()
        {
            var vacRef = _objectContext.GetVacancyReference();
            _formCompletionHelper.EnterText(SearchInput, vacRef);
            _formCompletionHelper.Click(SearchButton);
            _pageInteractionHelper.WaitforURLToChange($"searchTerm={vacRef}");
        }
    }
}
