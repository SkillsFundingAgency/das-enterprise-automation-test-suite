using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class CheckPageUsingPageTitle(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}