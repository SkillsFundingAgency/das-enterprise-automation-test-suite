using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.CheckPage;

public abstract class CheckPage(ScenarioContext context) : VerifyBasePage(context)
{
    protected override string PageTitle { get; }

    protected abstract By Identifier { get; }

    protected override bool CanAnalyzePage => false;

    public virtual bool IsPageDisplayed()
    {
        var idenifier = Identifier;

        SetDebugInformation($"Check page using Identifier: '{idenifier}'");

        return pageInteractionHelper.IsElementDisplayedAfterPageLoad(idenifier);
    }
}
