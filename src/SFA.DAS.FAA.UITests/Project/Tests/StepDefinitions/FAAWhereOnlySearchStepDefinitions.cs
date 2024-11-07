using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAWhereOnlySearchStepDefinitions(ScenarioContext context)
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _context = context;

        [When(@"the user does a where only search '([^']*)'")]
        public void WhenTheUserDoesAWhereOnlySearch(string whereText)
        {
            new FAASignedInLandingBasePage(_context).SearchByWhere(whereText);
        }
    }
}
