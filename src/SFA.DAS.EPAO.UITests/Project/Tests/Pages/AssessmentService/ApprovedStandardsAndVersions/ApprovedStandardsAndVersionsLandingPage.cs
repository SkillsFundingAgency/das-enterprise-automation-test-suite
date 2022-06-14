namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApprovedStandardsAndVersions;

public class ApprovedStandardsAndVersionsLandingPage : EPAO_BasePage
{
    protected override string PageTitle => "Approved standards and versions";

    #region Locators
    private static By AssociateProjectManagerLink => By.CssSelector("a[href='/standard/view-standard/ST0310']");
    #endregion

    public ApprovedStandardsAndVersionsLandingPage(ScenarioContext context) : base(context) => VerifyPage();

    public StandardDetailsForAssociateProjectManagerPage ClickOnAssociateProjectManagerLink()
    {
        formCompletionHelper.ClickElement(AssociateProjectManagerLink);
        return new(context);
    }
}