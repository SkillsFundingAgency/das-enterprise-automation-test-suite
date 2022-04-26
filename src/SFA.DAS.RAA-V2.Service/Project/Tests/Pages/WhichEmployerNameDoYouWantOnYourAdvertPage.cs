using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class WhichEmployerNameDoYouWantOnYourAdvertPage : EmployerNameBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "What employer name do you want on your advert?" : "What employer name do you want to go on the vacancy?";

        public WhichEmployerNameDoYouWantOnYourAdvertPage(ScenarioContext context) : base(context) { }
    }
}
