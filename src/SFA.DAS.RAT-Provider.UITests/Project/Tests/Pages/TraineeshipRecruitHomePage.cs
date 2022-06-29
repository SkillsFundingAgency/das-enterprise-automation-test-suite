using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;

public class TraineeshipRecruitHomePage : TraineeshipRecruitBasePage
{
    public TraineeshipRecruitHomePage(ScenarioContext context) : base(context)
    {
    }

    protected override string PageTitle => "Create a vacancy";
}