using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class EnterTheNameOfTheTrainingProviderPage(ScenarioContext context) : ChooseTrainingProviderPage(context)
    {
        protected override string PageTitle => "Who is your training provider?";
    }
}