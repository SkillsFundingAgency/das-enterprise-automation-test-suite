using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class WhichEmployerNameDoYouWantOnYourAdvertPage(ScenarioContext context) : EmployerNameBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "What employer name do you want on your advert?" : "What employer name do you want on the vacancy?";
    }
}
