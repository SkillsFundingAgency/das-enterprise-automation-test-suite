using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class EnterTheNameOfTheTrainingProviderPage(ScenarioContext context) : ChooseTrainingProviderPage(context)
    {
        protected override string PageTitle => "Enter the name of the training provider";
    }
}