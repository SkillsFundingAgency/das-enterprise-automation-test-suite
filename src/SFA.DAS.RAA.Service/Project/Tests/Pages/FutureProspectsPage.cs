using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class FutureProspectsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "What is the expected career progression after this apprenticeship?";

        private static By IframeBody => By.CssSelector(".mce-content-body ");
        private static By FutureProspect => By.Id("FutureProspects_ifr");

        public ThingsToConsiderPage EnterFutureProspect()
        {
            javaScriptHelper.SwitchFrameAndEnterText(FutureProspect, IframeBody, rAADataHelper.VacancyOutcome);
            Continue();
            return new ThingsToConsiderPage(context);
        }
    }
}
