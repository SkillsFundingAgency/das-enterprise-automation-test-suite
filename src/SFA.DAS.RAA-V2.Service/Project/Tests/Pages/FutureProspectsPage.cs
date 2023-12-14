using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class FutureProspectsPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => IsTraineeship ? "What is the expected career progression after this traineeship?" : "What is the expected career progression after this apprenticeship?";

        private static By IframeBody => By.CssSelector(".mce-content-body ");
        private static By FutureProspect => By.Id("FutureProspects_ifr");

        public ThingsToConsiderPage EnterFutureProspect()
        {
            javaScriptHelper.SwitchFrameAndEnterText(FutureProspect, IframeBody, rAAV2DataHelper.VacancyOutcome);
            Continue();
            return new ThingsToConsiderPage(context);
        }
    }
}
