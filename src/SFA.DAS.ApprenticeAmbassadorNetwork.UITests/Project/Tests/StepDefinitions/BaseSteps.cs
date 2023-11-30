using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;

public abstract class BaseSteps
{
    protected readonly ScenarioContext context;

    protected readonly ObjectContext objectContext;

    protected readonly RestartWebDriverHelper _restartWebDriverHelper;

    protected readonly AANSqlHelper _aanSqlHelper;

    public BaseSteps(ScenarioContext context)
    {
        this.context = context;

        objectContext = context.Get<ObjectContext>();

        _restartWebDriverHelper = new RestartWebDriverHelper(context);

        _aanSqlHelper = context.Get<AANSqlHelper>();
    }
}