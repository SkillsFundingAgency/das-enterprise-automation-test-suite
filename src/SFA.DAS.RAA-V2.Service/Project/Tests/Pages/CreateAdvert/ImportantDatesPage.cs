using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ImportantDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Important dates" : "Closing and start dates";

        public ImportantDatesPage(ScenarioContext context) : base(context) { }

        public DurationPage EnterImportantDates(bool disabilityConfidence)
        {
            EnterDates(disabilityConfidence);
            return new DurationPage(context);
        }
        public WorkExperienceProvidedPage EnterTraineeshipDates(bool disabilityConfidence)
        {
            EnterDates(disabilityConfidence);
            return new WorkExperienceProvidedPage(context);
        }
        private void EnterDates(bool disabilityConfidence)
        {
            ClosingDate(rAAV2DataHelper.VacancyClosing);
            StartDate(rAAV2DataHelper.VacancyStart);

            if (disabilityConfidence)
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(IsDisabilityConfident));
            }

            Continue();

            var expectedUrl = IsTraineeship ? "work-experience" : "duration"; 
            
            pageInteractionHelper.WaitforURLToChange(expectedUrl);
            
        }
    }
}
