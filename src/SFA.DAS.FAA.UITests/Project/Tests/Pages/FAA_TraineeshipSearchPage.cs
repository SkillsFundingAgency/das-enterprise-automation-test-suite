using OpenQA.Selenium;
using SFA.DAS.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Find a traineeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By Location => By.Id("Location");
        private By ReferenceNumber => By.Id("ReferenceNumber");
        private By Distance => By.Id("loc-within");

        public FAA_TraineeshipSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public new FAA_ApprenticeSummaryPage SearchByReferenceNumber()
        {
            _formCompletionHelper.EnterText(Location, string.Empty);
            _formCompletionHelper.Click(Search);
            _formCompletionHelper.EnterText(ReferenceNumber, _objectContext.GetVacancyReference());
            base.SearchByReferenceNumber();
            return new FAA_ApprenticeSummaryPage(_context);
        }

        public FAA_TraineeshipSearchResultsPage SearchForAVacancy(string location)
        {
            _formCompletionHelper.EnterText(Location, location);
            _formCompletionHelper.Click(Search);
            _pageInteractionHelper.WaitforURLToChange("/traineeships/search?Hash=");

            return new FAA_TraineeshipSearchResultsPage(_context);
        }
    }
}
