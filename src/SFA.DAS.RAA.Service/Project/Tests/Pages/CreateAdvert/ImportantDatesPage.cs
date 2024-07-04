using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ImportantDatesPage(ScenarioContext context) : VacancyDatesBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Closing and start date" : "Closing and start dates";

        public DurationPage EnterImportantDates()
        {
            EnterDates();
            return new DurationPage(context);
        }
        public WorkExperienceProvidedPage EnterTraineeshipDates()
        {
            EnterDates();
            return new WorkExperienceProvidedPage(context);
        }
        private void EnterDates()
        {
            ClosingDate(rAADataHelper.VacancyClosing);
            StartDate(rAADataHelper.VacancyStart);
            Continue();
            pageInteractionHelper.WaitforURLToChange("duration");

        }
    }
}
