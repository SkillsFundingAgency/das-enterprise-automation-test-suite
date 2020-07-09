using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class WhichEmployerNameDoYouWantOnYourAdvertPage : EmployerNameBasePage
    {
        protected override string PageTitle => "Which employer name do you want on your advert?";

        public WhichEmployerNameDoYouWantOnYourAdvertPage(ScenarioContext context) : base(context) { }
    }
}
