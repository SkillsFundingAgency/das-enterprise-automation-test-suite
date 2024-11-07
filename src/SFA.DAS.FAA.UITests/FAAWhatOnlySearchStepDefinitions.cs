using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests
{
    [Binding]
    public class FAAWhatOnlySearchStepDefinitions(ScenarioContext context)
    {
        private readonly IWebDriver;
        private readonly ScenarioContext _context = context;
        private readonly FAASignedInLandingBasePage _signedInLandingPage;

        [When(@"the user does a what only search '([^']*)'")]
        public void WhenTheUserDoesAWhatOnlySearch(string whatText)
        {

            new FAASignedInLandingBasePage(_context).SearchByWhat(whatText);

        }
    }
}
