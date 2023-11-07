namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public abstract class CheckASLandingPage : CheckPageUsingShorterTimeOut
{

    public CheckASLandingPage(ScenarioContext context) : base(context)
    {

    }

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}