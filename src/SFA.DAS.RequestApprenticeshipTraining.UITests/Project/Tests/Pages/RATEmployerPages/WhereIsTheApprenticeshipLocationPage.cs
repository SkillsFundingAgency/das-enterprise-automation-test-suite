using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class WhereIsTheApprenticeshipLocationPage : RatProjectBasePage
    {
        protected override By PageHeader => dynamicPageHeader;

        private readonly By dynamicPageHeader;

        public WhereIsTheApprenticeshipLocationPage(ScenarioContext context, bool IsSingleLocation) : base(context, false)
        {
            dynamicPageHeader = IsSingleLocation ? PageHeaderForSingleLocation : PageHeaderForMultipleLocation;

            VerifyPage();
        }

        protected override string PageTitle => "Where is the apprenticeship location?";

        private static By PageHeaderForMultipleLocation => By.CssSelector(".govuk-fieldset__heading");

        private static By PageHeaderForSingleLocation => By.CssSelector("label[for='SingleLocation']");

        #region Locators
        private static By MultipleLocation => By.CssSelector("label.govuk-checkboxes__label");
        #endregion

        public SelectTrainingOptionsPage EnterCityTownPostcode()
        {
            new ApprenticeshipLocationAutoCompleteHelper(context).SelectFromAutoCompleteList(RandomDataGenerator.RandomTown());

            Continue();

            return new SelectTrainingOptionsPage(context);
        }

        public SelectTrainingOptionsPage ChooseRegion()
        {
            var listOfRegions = pageInteractionHelper.FindElements(MultipleLocation);

            var firstRegion = RandomDataGenerator.GetRandomElementFromListOfElements(listOfRegions);

            listOfRegions.Remove(firstRegion);

            var secondRegion = RandomDataGenerator.GetRandomElementFromListOfElements(listOfRegions);

            formCompletionHelper.ClickElement(firstRegion);

            formCompletionHelper.ClickElement(secondRegion);

            Continue();

            return new SelectTrainingOptionsPage(context);
        }
    }

    public class ApprenticeshipLocationAutoCompleteHelper(ScenarioContext context) : AutoCompleteHelper(context)
    {
        protected override string SearchPage => "Apprenticeship Location";

        protected override By SearchTextInput => By.CssSelector("input[id='SingleLocation']");

        protected override By AutoCompleteMenu => By.CssSelector("[id='SingleLocation__listbox']");

        protected override By NthOption(int i) => By.CssSelector($"[id='SingleLocation__option--{i}']");

    }
}


