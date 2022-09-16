using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Edit advert dates" : "Edit vacancy dates";

        public EditVacancyDatesPage(ScenarioContext context) : base(context) { }

        public EmployerVacancySearchResultPage EnterVacancyDates()
        {
            ClosingDate(rAAV2DataHelper.EditedVacancyClosing);
            StartDate(rAAV2DataHelper.EditedVacancyStart);
            Continue();
            return new EmployerVacancySearchResultPage(context);
        }

        public EditVacancyPage EnterPossibleStartDate()
        {
            // Vacancy dates are edited.
            StartDate(rAAV2DataHelper.EditedVacancyStart);
            formCompletionHelper.ClickLinkByText("Cancel");
            return new EditVacancyPage(context);
        }
    }
}
