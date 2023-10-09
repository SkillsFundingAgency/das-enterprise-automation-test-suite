using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class CheckPage : VerifyBasePage
{
    protected override string PageTitle { get; }

    protected abstract By Identifier { get; }

    protected override bool CanAnalyzePage => false;

    public CheckPage(ScenarioContext context) : base(context) { }

    public virtual bool IsPageDisplayed() => pageInteractionHelper.IsElementDisplayedAfterPageLoad(Identifier);
}
