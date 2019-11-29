using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_SearchCandidatesPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for a candidate";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By FirstName => By.Id("SearchViewModel_FirstName");

        private By LastName => By.Id("SearchViewModel_LastName");

        private By SearchCandidate => By.Id("search-candidates-button");

        private By SelectCandidateLinks => By.CssSelector("a");

        public RAA_SearchCandidatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_SearchCandidatesPage Search()
        {
            formCompletionHelper.EnterText(FirstName, "H");
            formCompletionHelper.EnterText(LastName, "C");
            formCompletionHelper.Click(SearchCandidate);
            return this;
        }

        public RAA_CandidateApplicationPage SelectACandidate()
        {
            var links = _pageInteractionHelper.GetLinks(SelectCandidateLinks, "Select candidate");
            formCompletionHelper.ClickElement(dataHelper.GetRandomElementFromListOfElements(links));
            return new RAA_CandidateApplicationPage(_context);
        }
    }
}
