using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Steps;

[Binding]
public sealed class TimerSteps
{
    private const int MilliSecondsPerSecond = 1000;
    private readonly ScenarioContext _scenarioContext;

    public TimerSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the user waits for (.*) seconds")]
    public void GivenAUserWaitsForSeconds(int waitInSeconds)
    {
        Thread.Sleep(waitInSeconds*MilliSecondsPerSecond);
    }
}