namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public abstract class IdamsLoginBasePage : VerifyBasePage
{
    protected static By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

    protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true) : base(context)
    {
        if (verifypage) VerifyPage();
    }

    public void LoginToPireanPreprod() => formCompletionHelper.Click(PireanPreprod);
}
