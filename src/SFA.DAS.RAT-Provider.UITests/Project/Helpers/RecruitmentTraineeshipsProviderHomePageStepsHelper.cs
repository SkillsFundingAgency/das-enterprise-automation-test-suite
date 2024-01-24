using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public class RecruitmentTraineeshipsProviderHomePageStepsHelper(ScenarioContext context)
    {
        public TraineeshipRecruitHomePage GoToTraineeshipRecruitmentProviderHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(context).GoToProviderHomePage(newTab);

            return new TraineeshipRecruitHomePage(context, false).GoToTraineeshipHomePage();
        }
    }
}