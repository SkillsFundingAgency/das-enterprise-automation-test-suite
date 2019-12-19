using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{

    public class ImportantDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => "Important dates";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ImportantDatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public DurationPage EnterImportantDates()
        {
            ClosingDate(dataHelper.VacancyClosing);
            StartDate(dataHelper.VacancyStart);
            Continue();
            return new DurationPage(_context);
        }
    }
}
