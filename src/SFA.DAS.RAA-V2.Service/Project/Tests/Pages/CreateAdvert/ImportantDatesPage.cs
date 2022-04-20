using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ImportantDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => "Important dates";

        public ImportantDatesPage(ScenarioContext context) : base(context) { }

        public DurationPage EnterImportantDates(bool disabilityConfidence)
        {
            ClosingDate(rAAV2DataHelper.VacancyClosing);
            StartDate(rAAV2DataHelper.VacancyStart);

            if (disabilityConfidence)
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(IsDisabilityConfident));
            }

            Continue();
            pageInteractionHelper.WaitforURLToChange("duration");
            return new DurationPage(context);
        }
    }
}
