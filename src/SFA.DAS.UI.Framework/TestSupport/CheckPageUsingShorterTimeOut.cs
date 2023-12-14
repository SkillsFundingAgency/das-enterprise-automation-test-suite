using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class CheckPageUsingShorterTimeOut(ScenarioContext context) : CheckPage(context)
{
    protected readonly CheckPageInteractionHelper checkPageInteractionHelper = context.Get<CheckPageInteractionHelper>();

    public override bool IsPageDisplayed() => IsPageDisplayed(() => checkPageInteractionHelper.VerifyPage(Identifier));

    protected bool IsPageDisplayed(Func<bool> predicate) => checkPageInteractionHelper.WithoutImplicitWaits(predicate);
}
