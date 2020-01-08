using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ImportantDatesPage : VacancyDatesBasePage
    {
        protected override string PageTitle => "Important dates";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionhelper;
        #endregion

        public ImportantDatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionhelper = context.Get<PageInteractionHelper>();
        }

        public DurationPage EnterImportantDates(bool disabilityConfidence)
        {
            ClosingDate(dataHelper.VacancyClosing);
            StartDate(dataHelper.VacancyStart);

            if (disabilityConfidence)
            {
                formCompletionHelper.ClickElement(() => _pageInteractionhelper.FindElement(IsDisabilityConfident));
            }

            Continue();
            return new DurationPage(_context);
        }
    }
}
