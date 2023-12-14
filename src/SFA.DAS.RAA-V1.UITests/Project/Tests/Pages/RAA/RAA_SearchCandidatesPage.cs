using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_SearchCandidatesPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for a candidate";

        private By NoCandidateInfo => By.ClassName("info-summary");

        private By FirstName => By.Id("SearchViewModel_FirstName");

        private By LastName => By.Id("SearchViewModel_LastName");

        private By SearchCandidate => By.Id("search-candidates-button");

        private By SelectCandidateLinks => By.CssSelector("a");

        public RAA_SearchCandidatesPage(ScenarioContext context) : base(context) { }

        public RAA_SearchCandidatesPage Search()
        {
            var (_, _, firstname, lastname) = objectContext.GetFAALogin();
            formCompletionHelper.EnterText(FirstName, firstname);
            formCompletionHelper.EnterText(LastName, lastname);
            formCompletionHelper.Click(SearchCandidate);
            return this;
        }

        public RAA_SearchCandidatesPage VerifyCandidateDeletion()
        {
            pageInteractionHelper.VerifyText(NoCandidateInfo, "There are currently no candidates that match your search.");
            return this;
        }

        public RAA_CandidateApplicationPage SelectACandidate()
        {
            var links = pageInteractionHelper.GetLinks(SelectCandidateLinks, "Select candidate");
            formCompletionHelper.ClickElement(RandomDataGenerator.GetRandomElementFromListOfElements(links));
            return new RAA_CandidateApplicationPage(context);
        }
    }
}
