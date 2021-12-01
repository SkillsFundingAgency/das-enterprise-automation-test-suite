using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ImportantDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => "Important dates";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ImportantDatesPage(ScenarioContext context) : base(context) => _context = context;

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
            return new DurationPage(_context);
        }
    }
}
