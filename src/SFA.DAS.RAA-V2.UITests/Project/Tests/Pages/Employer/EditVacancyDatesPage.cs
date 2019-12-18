using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class EditVacancyDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => "Edit vacancy dates";

        protected override By PageHeader => By.CssSelector(".govuk-heading-m");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EditVacancyDatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public EditVacancyPage EnterVacancyClosingDate()
        {
            ClosingDate(dataHelper.EditedVacancyClosing);
            Continue();
            return new EditVacancyPage(_context);
        }

        public EditVacancyPage EnterPossibleStartDate()
        {
            StartDate(dataHelper.EditedVacancyStart);
            Continue();
            return new EditVacancyPage(_context);
        }
    }
}
