using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ThingsToConsiderPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Other requirements" : "Other requirements";

        private static By ThingsToConsider => By.CssSelector("#ThingsToConsider");

        public PreviewYourAdvertOrVacancyPage EnterThingsToConsider()
        {
            formCompletionHelper.EnterText(ThingsToConsider, rAADataHelper.OptionalMessage);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage EnterThingsToConsiderAndReturnToCreateAdvert(bool optionalFields)
        {
            if (optionalFields) formCompletionHelper.EnterText(ThingsToConsider, rAADataHelper.OptionalMessage);
            Continue();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
