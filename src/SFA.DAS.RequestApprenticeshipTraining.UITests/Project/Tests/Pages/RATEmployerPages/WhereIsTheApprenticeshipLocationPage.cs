using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class WhereIsTheApprenticeshipLocationPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "Where is the apprenticeship location?";

        #region Locators
        private static By EnterLocation => By.CssSelector(".autocomplete__input autocomplete__input--default");
        private static By ClickEastMidlands => By.LinkText("Derby");
        #endregion

        public SelectTrainingOptionsPage EnterCityTownPostcode()
        {
            formCompletionHelper.EnterText(EnterLocation, "CV1 2WT");
            Continue();
            return new SelectTrainingOptionsPage(context);
        }

        public SelectTrainingOptionsPage ChooseRegion()
        {
            formCompletionHelper.Click(ClickEastMidlands);
            Continue();
            return new SelectTrainingOptionsPage(context);
        }
    }
}
