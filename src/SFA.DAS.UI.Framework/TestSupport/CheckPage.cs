using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class CheckPage(ScenarioContext context) : VerifyBasePage(context)
{
    protected override string PageTitle { get; }

    protected abstract By Identifier { get; }

    protected override bool CanAnalyzePage => false;

    public virtual bool IsPageDisplayed() => pageInteractionHelper.IsElementDisplayedAfterPageLoad(Identifier);
}
