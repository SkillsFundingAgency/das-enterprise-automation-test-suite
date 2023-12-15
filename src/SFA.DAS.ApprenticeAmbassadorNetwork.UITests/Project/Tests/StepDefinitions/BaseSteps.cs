namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;

public abstract class BaseSteps(ScenarioContext context)
{
    protected readonly ScenarioContext context = context;

    protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

    protected readonly RestartWebDriverHelper _restartWebDriverHelper = new(context);

    protected readonly AANSqlHelper _aanSqlHelper = context.Get<AANSqlHelper>();
}