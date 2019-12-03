using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RAAChangeApplicationStatus
    {
        private readonly RAAStepsHelper _raaStepsHelper;

        public RAAChangeApplicationStatus(ScenarioContext context)
        {
            _raaStepsHelper = new RAAStepsHelper(context);
        }

        [Then(@"Provider is able to change the status of the new application to '(.*)'")]
        public void ThenProviderIsAbleToChangeTheStatusOfTheNewApplicationTo(string newStatus)
        {
            ChangeStatus(newStatus);
        }

        [Then(@"Provider is able to change the status of the In progress application to '(.*)'")]
        public void ThenProviderIsAbleToChangeTheStatusOfTheInProgressApplicationTo(string newStatus)
        {
            ChangeStatus("In progress")
                .ViewApplication()
                .ChangeStatus(newStatus);
        }

        private RAA_VacancySummaryPage ChangeStatus(string newStatus)
        {
            return _raaStepsHelper.GoToRAAHomePage(false)
                            .SelectLiveVacancyWithNewApplications()
                            .ViewApplication()
                            .ChangeStatus(newStatus);
        }

    }
}

