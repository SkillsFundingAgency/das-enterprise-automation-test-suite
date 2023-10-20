namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class EsfaAdminServiceStartPage : IdamsLoginBasePage
{
    protected override string PageTitle => "Apprenticeship service admin";

    private static By StartNowCssSelector => IdamsPageSelector.StartNowButton;

    public EsfaAdminServiceStartPage(ScenarioContext context) : base(context) { }

    public PreProdDIGBEADFSPage StartNow()
    {
        ClickStartNowButton();
        return new PreProdDIGBEADFSPage(context);
    }

    public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowCssSelector);

}
