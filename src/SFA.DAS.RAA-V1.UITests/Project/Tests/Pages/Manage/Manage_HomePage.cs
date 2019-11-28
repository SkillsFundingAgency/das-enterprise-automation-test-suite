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

        public Manage_HelpdeskAdviserPage HelpdeskAdviser()
        {
            ChangeToHelpdeskAdviser();

            return new Manage_HelpdeskAdviserPage(_context);
        }

        public Manage_EnterBasicVacancyDetailsPage EditOrCommentTitle()
        {
            EditOrComment("title");

            return new Manage_EnterBasicVacancyDetailsPage(_context);
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

        private void EditOrComment(string field)
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

        private void TodayVacancy()
        {
            ChangeToVacancyReviewer();

            formCompletionHelper.ClickLinkByText(VacancyFilters, "Today");
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

        private void ReviewVacancy()
        {
            tableRowHelper.SelectRowFromTable("Review", raadataHelper.VacancyTitle);
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

        private void ChangeToVacancyReviewer()
        {
            ChangeFilter(ChangeRole, InputChangeRole, "Vacancy reviewer");

            ChangeFilter(ChangeTeam, InputChangeTeam, "West Midlands");
        }

        private void ChangeToHelpdeskAdviser()
        {
            ChangeFilter(ChangeRole, InputChangeRole, "Helpdesk adviser");
        }
    }
}
