using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_HomePage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Agency home";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By ChangeTeam => By.CssSelector("#select2-chosen-2");

        private By ChangeRole => By.CssSelector("#select2-chosen-1");

        private By InputChangeTeam => By.Id("s2id_autogen2_search");

        private By InputChangeRole => By.Id("s2id_autogen1_search");

        private By Filters => By.CssSelector(".column-one-quarter");

        private By DateFilter => By.CssSelector(".bold-xsmall");

        private By VacancyFilters => By.CssSelector(".column-one-quarter .bold-xsmall");

        private By NoOfVacancy => By.CssSelector(".bold-xlarge");

        private By VacancyReviewLink() => By.CssSelector($"a[href*='vacancyReferenceNumber={_objectContext.GetVacancyReference()}']");

        public Manage_HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public Manage_HelpdeskAdviserPage HelpdeskAdviser()
        {
            ChangeToHelpdeskAdviser();

            return new Manage_HelpdeskAdviserPage(_context);
        }

        public Manage_VacancyPreviewPage ReviewAVacancy()
        {
            TodayVacancy();

            formCompletionHelper.Click(VacancyReviewLink());

            return new Manage_VacancyPreviewPage(_context);
        }

        private void TodayVacancy()
        {
            pageInteractionHelper.Verify(() =>
            {
                ChangeToVacancyReviewer();

                formCompletionHelper.ClickLinkByText(VacancyFilters, "Today");

                var filters = pageInteractionHelper.FindElements(Filters);
                foreach (var filter in filters)
                {
                    var filterelement = filter.FindElement(DateFilter);
                    if (filterelement.Text == "Today")
                    {
                        if (filter.FindElement(NoOfVacancy).Text == "0")
                        {
                            throw new Exception($"Element verification failed: There are no vacancy found today in Manage");
                        }
                    }
                }

                return true;
            }, () => AgentHome());
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