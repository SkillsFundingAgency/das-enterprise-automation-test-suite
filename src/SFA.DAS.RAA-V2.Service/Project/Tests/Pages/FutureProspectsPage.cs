using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class FutureProspectsPage : Raav2BasePage
    {
        protected override string PageTitle => IsTraineeship ? "What is the expected career progression after this traineeship?" : "What is the expected career progression after this apprenticeship?";

        private By IframeBody => By.CssSelector(".mce-content-body ");
        private By FutureProspect => By.Id("FutureProspects_ifr");
        
        public FutureProspectsPage(ScenarioContext context) : base(context) { }

        public ThingsToConsiderPage EnterFutureProspect()
        {
            javaScriptHelper.SwitchFrameAndEnterText(FutureProspect, IframeBody, rAAV2DataHelper.VacancyOutcome);
            Continue();
            return new ThingsToConsiderPage(context);
        }
    }
}
