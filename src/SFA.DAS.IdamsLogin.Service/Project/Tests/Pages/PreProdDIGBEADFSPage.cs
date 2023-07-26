namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class CheckPreProdDIGBEADFSPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle { get; }

    protected override By Identifier => IdamsPageSelector.Access1Staff;

    public CheckPreProdDIGBEADFSPage(ScenarioContext context) : base(context) { }
}

public class PreProdDIGBEADFSPage : IdamsLoginBasePage
{
    protected override string PageTitle => "PreProd DIGBE ADFS";

    protected override bool CanAnalyzePage => false;

    public PreProdDIGBEADFSPage(ScenarioContext context) : base(context, false) => VerifyPageAfterRefresh(PireanPreprod);

    public void LoginToAccess1Staff() => formCompletionHelper.Click(IdamsPageSelector.Access1Staff);
}
