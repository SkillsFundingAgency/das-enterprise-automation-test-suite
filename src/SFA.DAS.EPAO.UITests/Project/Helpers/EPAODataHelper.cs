using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAODataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;

        public EPAODataHelper(ScenarioContext context)
        {
            _randomDataGenerator = context.Get<RandomDataGenerator>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public void ClickAddressFromAutoSuggestOptions(By PostCodeAutocompleteElements)
        {
            _formCompletionHelper.ClickElement(() =>
            {
                var postCodeAutocompleteAddresses = _pageInteractionHelper.FindElements(PostCodeAutocompleteElements);
                return postCodeAutocompleteAddresses[_randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, postCodeAutocompleteAddresses.Count - 1)];
            });
        }

        public void EnterDate(By locator, int text) => _formCompletionHelper.EnterText(locator, text);
    }
}
