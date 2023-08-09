using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ProviderApplicationUnsuccessfulPage : Raav2BasePage
    {
        protected static By NotificationBanner => By.CssSelector(".govuk-notification-banner");

        protected override By PageHeader => NotificationBanner;

        public ProviderApplicationUnsuccessfulPage(ScenarioContext context) : base(context) 
        {
                
        }

        protected override string PageTitle => $"{rAAV2DataHelper.CandidateFullName}'s application made unsuccessful.";
    }
}
