namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public abstract class IdamsLoginBasePage : VerifyBasePage
{
    protected static By PireanPreprod => IdamsPageSelector.PireanPreprod;

    protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true) : base(context)
    {
        if (verifypage) VerifyPage();
    }

    public void LoginToPireanPreprod() => formCompletionHelper.Click(PireanPreprod);

}
