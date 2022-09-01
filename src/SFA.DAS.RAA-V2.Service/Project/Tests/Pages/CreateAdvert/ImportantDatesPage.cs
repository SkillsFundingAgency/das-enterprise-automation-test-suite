using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ImportantDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Closing and start date" : "Closing and start dates";

        public ImportantDatesPage(ScenarioContext context) : base(context) { }

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
            ClosingDate(rAAV2DataHelper.VacancyClosing);
            StartDate(rAAV2DataHelper.VacancyStart);
            Continue();

            var expectedUrl = IsTraineeship ? "work-experience" : "duration"; 
            
            pageInteractionHelper.WaitforURLToChange(expectedUrl);
            
        }
    }
}
