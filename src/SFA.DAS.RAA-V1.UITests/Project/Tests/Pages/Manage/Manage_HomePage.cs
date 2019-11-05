using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_HomePage : BasePage
    {
        protected override string PageTitle => "Agency home";
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly RAADataHelper _dataHelper;
        #endregion

        private By ChangeTeam => By.CssSelector("#select2-chosen-2");

        private By ChangeRole => By.CssSelector("#select2-chosen-1");

        private By InputChangeTeam => By.Id("s2id_autogen2_search");

        private By InputChangeRole => By.Id("s2id_autogen1_search");

        private By Filters => By.CssSelector(".column-one-quarter");

        private By DateFilter => By.CssSelector(".bold-xsmall");

        private By ApproveAndContinue => By.Name("VacancyQAAction");
        
        private By ClickAgencyHome => By.Id("proposition-name");

        private By NoResults => By.XPath("//td[@colspan='6'][contains(.,'No results')]");

        private By SignOutCss => By.Id("signout-link");

        private By VacancyFilters => By.CssSelector(".column-one-quarter .bold-xsmall");

        private By NoOfVacancy => By.CssSelector(".bold-xlarge");

        public Manage_HomePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }

        protected void TodayVacancy()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLink(VacancyFilters, "Today"));
        }

        private bool AretherAnyVacancyToday()
        {
            var filters = _pageInteractionHelper.FindElements(Filters);
            foreach (var filter in filters)
            {
                var filterelement = filter.FindElement(DateFilter);
                if (filterelement.Text == "Today")
                {
                    return filter.FindElement(NoOfVacancy).Text != "0";
                }
            }
            return false;
        }

        private void ChangeFilter(By locator, By inputlocator, string changeTo)
        {
            if (!(_pageInteractionHelper.GetText(locator).Contains(changeTo)))
            {
                _formCompletionHelper.Click(locator);
                _formCompletionHelper.EnterText(inputlocator, changeTo);
                _formCompletionHelper.SendKeys(inputlocator, Keys.Enter);
            }
        }

        public void ApproveAVacancy(string changeTeam, string changeRole)
        {
            ChangeFilter(ChangeTeam, InputChangeTeam, changeTeam);
            
            ChangeFilter(ChangeRole, InputChangeRole, changeRole);

            ApproveAVacancy();
        }

        public void ApproveAVacancy()
        {
            TodayVacancy();

            if (AretherAnyVacancyToday() == true)
            {
                _tableRowHelper.SelectRowFromTable("Review", _dataHelper.VacancyTitle);
                _formCompletionHelper.Click(ApproveAndContinue);
                _formCompletionHelper.Click(ClickAgencyHome);
                _formCompletionHelper.Click(SignOutCss);
            }
            else
            {
                _pageInteractionHelper.GetText(NoResults);
            }
        }
    }
}
