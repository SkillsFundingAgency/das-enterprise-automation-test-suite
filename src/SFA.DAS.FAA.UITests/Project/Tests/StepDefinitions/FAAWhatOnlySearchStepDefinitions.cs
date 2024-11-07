using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAWhatOnlySearchStepDefinitions(ScenarioContext context)
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _context = context;

        [When(@"the user does a what only search '([^']*)'")]
        public void WhenTheUserDoesAWhatOnlySearch(string whatText)
        {
            new FAASignedInLandingBasePage(_context).SearchByWhat(whatText);
        }
    }
}
