using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class EditVacancyDatesPage(ScenarioContext context) : VacancyDatesBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Edit advert dates" : "Edit vacancy dates";

        public EmployerVacancySearchResultPage EnterVacancyDates()
        {
            ClosingDate(rAADataHelper.EditedVacancyClosing);
            StartDate(rAADataHelper.EditedVacancyStart);
            Continue();
            return new EmployerVacancySearchResultPage(context);
        }

        public ProviderVacancySearchResultPage EnterProviderVacancyDates()
        {
            ClosingDate(rAADataHelper.EditedVacancyClosing);
            StartDate(rAADataHelper.EditedVacancyStart);
            Continue();
            return new ProviderVacancySearchResultPage(context);
        }

        public EditVacancyPage EnterPossibleStartDate()
        {
            // Vacancy dates are edited.
            StartDate(rAADataHelper.EditedVacancyStart);
            formCompletionHelper.ClickLinkByText("Cancel");
            return new EditVacancyPage(context);
        }
    }
}
