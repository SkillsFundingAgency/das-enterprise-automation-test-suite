namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages.LandingPage;

public class ASAdminLandingPage : IdamsLoginBasePage
{
    public static string ASAdminPageTitle => "Apprenticeship service admin";

    public static By ASAdminPageheader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => ASAdminPageTitle;

    protected override By PageHeader => ASAdminPageheader;

    public ASAdminLandingPage(ScenarioContext context) : base(context) { }

    public PreProdDIGBEADFSPage StartNow()
    {
        ClickStartNowButton();
        return new PreProdDIGBEADFSPage(context);
    }
}


public class CheckASAdminLandingPage: CheckPageUsingShorterTimeOut
{
    protected override string PageTitle => ASAdminLandingPage.ASAdminPageTitle;

    protected override By Identifier => ASAdminLandingPage.ASAdminPageheader;

    public CheckASAdminLandingPage(ScenarioContext context) : base(context) { }

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}