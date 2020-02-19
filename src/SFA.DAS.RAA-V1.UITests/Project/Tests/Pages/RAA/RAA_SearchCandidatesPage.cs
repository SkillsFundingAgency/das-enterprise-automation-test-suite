using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_SearchCandidatesPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for a candidate";

        private By NoCandidateInfo => By.ClassName("info-summary");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        #endregion

        private By FirstName => By.Id("SearchViewModel_FirstName");

        private By LastName => By.Id("SearchViewModel_LastName");

        private By SearchCandidate => By.Id("search-candidates-button");

        private By SelectCandidateLinks => By.CssSelector("a");
        
        public RAA_SearchCandidatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();           
            _objectcontext = context.Get<ObjectContext>();
        }

        public RAA_SearchCandidatesPage Search()
        {
            var (_, _, firstname, lastname) = _objectcontext.GetFAANewAccount();
            formCompletionHelper.EnterText(FirstName, firstname);
            formCompletionHelper.EnterText(LastName, lastname);
            formCompletionHelper.Click(SearchCandidate); 
            return this;
        }

        public RAA_SearchCandidatesPage VerifyCandidateDeletion()
        {
            _pageInteractionHelper.VerifyText(NoCandidateInfo, "There are currently no candidates that match your search.");
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
