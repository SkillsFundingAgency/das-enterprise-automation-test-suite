using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ThingsToConsiderPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Other requirements" : "Other requirements";
        private static By ThingsToConsiderIframe => By.Id("ThingsToConsider_ifr");
        private static By IframeBody => By.CssSelector(".mce-content-body");

        public PreviewYourAdvertOrVacancyPage EnterThingsToConsider()
        {
            javaScriptHelper.SwitchFrameAndEnterText(ThingsToConsiderIframe, IframeBody, rAADataHelper.OptionalMessage);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage EnterThingsToConsiderAndReturnToCreateAdvert(bool optionalFields)
        {
            if (optionalFields) javaScriptHelper.SwitchFrameAndEnterText(ThingsToConsiderIframe, IframeBody, rAADataHelper.OptionalMessage);
            Continue();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
