using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.CheckPage;

public abstract class CheckPageTitleShorterTimeOut(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    public override bool IsPageDisplayed() => IsPageDisplayedUsingPageTitle();
}

public abstract class CheckPageTitleLongerTimeOut(ScenarioContext context) : CheckPageUsingLongerTimeOut(context)
{
    public override bool IsPageDisplayed() => IsPageDisplayedUsingPageTitle();
}