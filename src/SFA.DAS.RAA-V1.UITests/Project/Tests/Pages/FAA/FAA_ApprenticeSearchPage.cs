using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_ApprenticeSearchPage : FAA_SearchVacancy
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By SearchField => By.Id("SearchField");

        protected By KeyWord => By.Id("Keywords");

        private By Location => By.Id("Location");

        private By Distance => By.Id("loc-within");

        private By ApprenticeshipLevel => By.Id("apprenticeship-level");

        public FAA_ApprenticeSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public FAA_SearchResultsPage SearchForAVacancy(string jobTitle, string location, string distance, string apprenticeshipLevel, string disabilityConfident)
        {
            _formCompletionHelper.SelectFromDropDownByValue(SearchField, "JobTitle");
            _formCompletionHelper.EnterText(KeyWord, jobTitle);
            _formCompletionHelper.EnterText(Location, location);
            _formCompletionHelper.SelectFromDropDownByText(Distance, distance);
            _formCompletionHelper.SelectFromDropDownByText(ApprenticeshipLevel, apprenticeshipLevel);
            if (disabilityConfident == "Yes")
            {
                _formCompletionHelper.SelectCheckBoxByText("Disability Confident");
            }

            _formCompletionHelper.Click(Search);
            
            _pageInteractionHelper.WaitforURLToChange("SearchField=JobTitle");

            return new FAA_SearchResultsPage(_context);
        }

        public new FAA_ApprenticeSummaryPage SearchByReferenceNumber()
        {
            _formCompletionHelper.SelectFromDropDownByValue(SearchField, "ReferenceNumber");
            _formCompletionHelper.EnterText(KeyWord, _objectContext.GetVacancyReference());
            
            base.SearchByReferenceNumber();

            return new FAA_ApprenticeSummaryPage(_context);
        }
    }
}
