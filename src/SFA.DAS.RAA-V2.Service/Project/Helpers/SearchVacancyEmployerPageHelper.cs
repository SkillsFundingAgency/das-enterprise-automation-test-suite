using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class SearchVacancyEmployerPageHelper
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV2DataHelper _dataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion
        private By SearchInput => By.CssSelector("#search-input");

        private By SearchButton => By.CssSelector("#search-submit-button");

        private By Manage => By.CssSelector("table tbody tr .govuk-link");

        public SearchVacancyEmployerPageHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<RAAV2DataHelper>();
        }

        public ManageRecruitPage SelectLiveVacancy()
        {
            _formCompletionHelper.ClickLinkByText("Live adverts");
            _pageInteractionHelper.WaitforURLToChange($"filter=Live");
            _formCompletionHelper.ClickElement(_dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(Manage)));
            return new ManageRecruitPage(_context);
        }

        public ManageRecruitPage SearchVacancyByVacancyReference()
        {
            SearchVacancy();
            return new ManageRecruitPage(_context);
        }

        public ReferVacancyPage SearchReferVacancy()
        {
            SearchVacancy();
            return new ReferVacancyPage(_context);
        }

        private void SearchVacancy()
        {
            var vacRef = _objectContext.GetVacancyReference();
            _formCompletionHelper.EnterText(SearchInput, vacRef); 
            _formCompletionHelper.Click(SearchButton);            
            _pageInteractionHelper.WaitforURLToChange($"searchTerm={vacRef}");
            _formCompletionHelper.ClickElement(_pageInteractionHelper.FindElement(Manage));                        
        }
    }
}
