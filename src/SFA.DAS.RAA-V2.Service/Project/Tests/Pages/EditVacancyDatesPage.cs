using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => "Edit vacancy dates";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EditVacancyDatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public EditVacancyPage EnterVacancyDates()
        {
            ClosingDate(rAAV2DataHelper.EditedVacancyClosing);
            StartDate(rAAV2DataHelper.EditedVacancyStart);
            Continue();
            return new EditVacancyPage(_context);
        }

        public EditVacancyPage EnterPossibleStartDate()
        {
            // Vacancy dates are edited.
            StartDate(rAAV2DataHelper.EditedVacancyStart);
            formCompletionHelper.ClickLinkByText("Cancel");
            return new EditVacancyPage(_context);
        }
    }
}
