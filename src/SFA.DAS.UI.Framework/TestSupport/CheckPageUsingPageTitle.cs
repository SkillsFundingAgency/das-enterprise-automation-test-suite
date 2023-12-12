using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class CheckPageUsingPageTitle : CheckPageUsingShorterTimeOut
{

    public CheckPageUsingPageTitle(ScenarioContext context) : base(context)
    {

    }

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}