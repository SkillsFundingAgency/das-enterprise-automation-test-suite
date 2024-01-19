using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.CheckPage;

public abstract class CheckPageUsingLongerTimeOut : CheckPageUsingTimeOut
{
    public CheckPageUsingLongerTimeOut(ScenarioContext context) : base(context) => checkPageInteractionHelper.UpdateTimeSpans(RetryTimeOut.GetTimeSpan([5, 5, 5, 5, 5]));
}