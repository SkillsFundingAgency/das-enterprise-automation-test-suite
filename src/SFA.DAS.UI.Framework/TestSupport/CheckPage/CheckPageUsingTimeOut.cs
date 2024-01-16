using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.CheckPage;

public abstract class CheckPageUsingTimeOut(ScenarioContext context) : CheckPage(context)
{
    protected readonly CheckPageInteractionHelper checkPageInteractionHelper = context.Get<CheckPageInteractionHelper>();

    public override bool IsPageDisplayed() => IsPageDisplayed(() => 
    {
        var idenifier = Identifier;

        SetDebugInformation($"Check page using Identifier: '{idenifier}'");

        return checkPageInteractionHelper.VerifyPage(idenifier); 
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

    private bool IsPageDisplayed(Func<bool> predicate) => checkPageInteractionHelper.WithoutImplicitWaits(predicate);
}
