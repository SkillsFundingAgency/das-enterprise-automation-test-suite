using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAABrowseByInterestsSteps(ScenarioContext context)
    {
        private readonly ScenarioContext _context = context;

        [When(@"the user searches for vacancies by '(.*)' option in the Browse Your Interests route")]
        public void WhenTheUserNavigatesToBrowseYourInterestsPage(string locationOption)
        {
            new FAASignedInLandingBasePage(_context).ClickBrowseByYourInterests().SelectCategoriesCheckBoxes().EnterLocationDetails(locationOption);
        }

    }
}
