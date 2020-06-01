using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Find a traineeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Location => By.Id("Location");
        private By ReferenceNumber => By.Id("ReferenceNumber");
        private By Distance => By.Id("loc-within");
        private By LocationErrorMessage => By.Id("error-summary");
        private By PartialLocationErrorMessage => By.CssSelector("[data-valmsg-for='Location']");

        public FAA_TraineeshipSearchPage(ScenarioContext context) : base(context) => _context = context;

        public new FAA_ApprenticeSummaryPage SearchByReferenceNumber()
        {
            SearchVacancyInFAA();
            return new FAA_ApprenticeSummaryPage(_context);
        }

        public FAA_TraineeshipNotAvailablePage SearchClosedVacancy()
        {
            SearchVacancyInFAA();
            return new FAA_TraineeshipNotAvailablePage(_context);
        }

        private void SearchVacancyInFAA()
        {
            formCompletionHelper.EnterText(Location, string.Empty);
            formCompletionHelper.Click(Search);
            formCompletionHelper.EnterText(ReferenceNumber, objectContext.GetVacancyReference());
            base.SearchByReferenceNumber();
        }

        private void EnterPostCode(string location)
        {
            formCompletionHelper.EnterText(Location, location);
            formCompletionHelper.Click(Search);
        }

        public FAA_TraineeshipSearchResultsPage SearchForAVacancy(string location)
        {
            EnterPostCode(location);      
            pageInteractionHelper.WaitforURLToChange("/traineeships/search?Hash=");

            return new FAA_TraineeshipSearchResultsPage(_context);
        }
    }
}
