namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public class PreProdDIGBEADFSPage : IdamsLoginBasePage
{
    protected override string PageTitle => "PreProd DIGBE ADFS";

    private static By Access1Staff => By.XPath("//span[contains(text(),'Access1 Staff')]");

    protected override bool CanAnalyzePage => false;

    public PreProdDIGBEADFSPage(ScenarioContext context) : base(context, false) => VerifyPageAfterRefresh(PireanPreprod);

    public void LoginToAccess1Staff() => formCompletionHelper.Click(Access1Staff);
}
