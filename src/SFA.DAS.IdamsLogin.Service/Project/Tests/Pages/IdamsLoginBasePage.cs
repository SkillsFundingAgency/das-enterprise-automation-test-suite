namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public abstract class IdamsLoginBasePage : VerifyBasePage
{
    protected static By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

    public static By StartNowButton => By.CssSelector(".govuk-button--start");

    protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true) : base(context)
    {
        if (verifypage) VerifyPage();
    }

    public void LoginToPireanPreprod() => formCompletionHelper.Click(PireanPreprod);

    public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowButton);

    public DfeSignInPage StartNowAndGoToDfeSignPage()
    {
        ClickStartNowButton();

        return new DfeSignInPage(context);
    }
}
