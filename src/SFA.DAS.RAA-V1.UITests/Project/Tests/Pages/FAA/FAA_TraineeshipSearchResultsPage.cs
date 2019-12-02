using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_TraineeshipSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By Location => By.Id("Location");
        private By ReferenceNumber => By.Id("ReferenceNumber");
        private By Distance => By.Id("loc-within");

        public FAA_TraineeshipSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public FAA_SearchResultsPage SearchForAVacancy(string location, string distance, string disabilityConfident)
        {
            _formCompletionHelper.EnterText(Location, location);
           
            _formCompletionHelper.SelectFromDropDownByText(Distance, distance);
            if (disabilityConfident == "Yes")
            {
                _formCompletionHelper.SelectCheckBoxByText("Disability Confident");
            }

            _formCompletionHelper.Click(Search);

            var urlChange = distance.Contains("miles") ? distance.Split(" ")[0] : "0";

            _pageInteractionHelper.WaitforURLToChange($"WithinDistance={urlChange}");

            return new FAA_SearchResultsPage(_context);
        }

    }
}
