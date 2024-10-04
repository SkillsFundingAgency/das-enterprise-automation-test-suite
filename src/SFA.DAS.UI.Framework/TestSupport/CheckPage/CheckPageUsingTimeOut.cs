using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.CheckPage;

public abstract class CheckPageUsingTimeOut(ScenarioContext context) : CheckPage(context)
{
    protected readonly CheckPageInteractionHelper checkPageInteractionHelper = context.Get<CheckPageInteractionHelper>();

    public override bool IsPageDisplayed() => IsPageDisplayed(() => 
    {
        var identfier = Identifier;

        SetDebugInformation($"Check the page using Identifier: '{identfier}'");

        return checkPageInteractionHelper.VerifyPage(identfier); 
    });

    protected bool IsPageDisplayedUsingPageTitle(string pageTitle) => IsPageDisplayed(() =>
    {
        SetDebugInformation($"Check page using Page title : '{pageTitle}'");

        return checkPageInteractionHelper.VerifyPage(Identifier, pageTitle);
    });

    protected bool IsPageDisplayedUsingPageTitle() => IsPageDisplayed(() => 
    {
        var pageTitle = PageTitle;

        SetDebugInformation($"Check page using Page title : '{pageTitle}'");

        return checkPageInteractionHelper.VerifyPage(Identifier, pageTitle); 
    });

    protected bool IsPageDisplayed(Func<bool> predicate) => checkPageInteractionHelper.WithoutImplicitWaits(predicate);
}
