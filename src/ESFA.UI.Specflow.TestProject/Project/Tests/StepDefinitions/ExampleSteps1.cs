using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.TestSupport;
using TestContext = NUnit.Framework.TestContext;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.TestProject.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExampleSteps1
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objecContext;

        public ExampleSteps1(ScenarioContext context, ObjectContext objecContext)
        {
            _context = context;
            _objecContext = objecContext;
        }

        [When(@"I click the same link")]
        public void WhenIClickTheSameLink()
        {
            var searchResultsPage = new SearchResultsPage(_context);
            var searchText = _objecContext.Get("searchText");
            TestContext.Progress.WriteLine($"Naivgating to {searchText} page");
            searchResultsPage.ClickDfeLink(searchText);
        }

    }
}
