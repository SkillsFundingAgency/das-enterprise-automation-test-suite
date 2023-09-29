using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ThingsToConsiderPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "What else would you like the applicant to consider? (optional)" : "What else do you want the applicant to consider? (optional)";

        private static By ThingsToConsider => By.CssSelector("#ThingsToConsider");

        public ThingsToConsiderPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage EnterThingsToConsider()
        {
            formCompletionHelper.EnterText(ThingsToConsider, rAAV2DataHelper.OptionalMessage);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage EnterThingsToConsiderAndReturnToCreateAdvert(bool optionalFields)
        {
            if (optionalFields) formCompletionHelper.EnterText(ThingsToConsider, rAAV2DataHelper.OptionalMessage);
            Continue();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
