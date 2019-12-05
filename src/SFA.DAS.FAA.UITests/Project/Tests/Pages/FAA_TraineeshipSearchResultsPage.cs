using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By Location => By.Id("Location");
        private By ReferenceNumber => By.Id("ReferenceNumber");
        private By Distance => By.Id("loc-within");

        public FAA_TraineeshipSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_TraineeshipSearchResultsPage SearchForAVacancy(string location, string distance)
        {
            _formCompletionHelper.EnterText(Location, location);

            _formCompletionHelper.SelectFromDropDownByText(Distance, distance);

            _formCompletionHelper.Click(Search);

            WaitforURLToChange(distance);

            return new FAA_TraineeshipSearchResultsPage(_context);
        }
    }
}
