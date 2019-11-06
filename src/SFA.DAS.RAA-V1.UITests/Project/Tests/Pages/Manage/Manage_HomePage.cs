using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_HomePage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Agency home";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeTeam => By.CssSelector("#select2-chosen-2");

        private By ChangeRole => By.CssSelector("#select2-chosen-1");

        private By InputChangeTeam => By.Id("s2id_autogen2_search");

        private By InputChangeRole => By.Id("s2id_autogen1_search");

        private By Filters => By.CssSelector(".column-one-quarter");

        private By DateFilter => By.CssSelector(".bold-xsmall");

        private By ApproveAndContinue => By.Name("VacancyQAAction");
        
        private By NoResults => By.XPath("//td[@colspan='6'][contains(.,'No results')]");

        private By VacancyFilters => By.CssSelector(".column-one-quarter .bold-xsmall");

        private By NoOfVacancy => By.CssSelector(".bold-xlarge");

        public Manage_HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        protected void TodayVacancy()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLink(VacancyFilters, "Today"));
        }

        private bool AretherAnyVacancyToday()
        {
            var filters = pageInteractionHelper.FindElements(Filters);
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

        public Manage_EnterBasicVacancyDetailsPage EditOrCommentTitle(string changeTeam, string changeRole)
        {
            ChangeFilters(changeTeam, changeRole);

            EditOrComment("title");

            return new Manage_EnterBasicVacancyDetailsPage(_context);
        }
        
        public void ApproveAVacancy(string changeTeam, string changeRole)
        {
            ChangeFilters(changeTeam, changeRole);

            ApproveAVacancy();
        }

        public void EditOrComment(string field)
        {
            TodayVacancy();

            if (AretherAnyVacancyToday() == true)
            {
                ReviewVacancy();
                formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref(field));
            }
            else
            {
                pageInteractionHelper.GetText(NoResults);
            }
        }

        public void ApproveAVacancy()
        {
            TodayVacancy();

            if (AretherAnyVacancyToday() == true)
            {
                ReviewVacancy();
                formCompletionHelper.Click(ApproveAndContinue);
                SignOut();
            }
            else
            {
                pageInteractionHelper.GetText(NoResults);
            }
        }

        private void ReviewVacancy()
        {
            tableRowHelper.SelectRowFromTable("Review", dataHelper.VacancyTitle);
        }

        private void ChangeFilter(By locator, By inputlocator, string changeTo)
        {
            if (!(pageInteractionHelper.GetText(locator).Contains(changeTo)))
            {
                formCompletionHelper.Click(locator);
                formCompletionHelper.EnterText(inputlocator, changeTo);
                formCompletionHelper.SendKeys(inputlocator, Keys.Enter);
            }
        }

        private void ChangeFilters(string changeTeam, string changeRole)
        {
            ChangeFilter(ChangeTeam, InputChangeTeam, changeTeam);

            ChangeFilter(ChangeRole, InputChangeRole, changeRole);
        }

    }
}
