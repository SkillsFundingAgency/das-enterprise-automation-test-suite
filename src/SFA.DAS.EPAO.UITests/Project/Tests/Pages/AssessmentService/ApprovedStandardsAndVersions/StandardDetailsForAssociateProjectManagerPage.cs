namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApprovedStandardsAndVersions;

public class StandardDetailsForAssociateProjectManagerPage : EPAO_BasePage
{
    protected override string PageTitle => "Associate project manager";

    #region Locators
    private static By AssociateProjectManagerOptInLinkForVersion1_1 => By.LinkText("Opt into standard version");
    #endregion

    public StandardDetailsForAssociateProjectManagerPage(ScenarioContext context) : base(context) => VerifyPage();

    public ConfirmOptInForAssociateProjectManagerPage ClickOnAssociateProjectManagerOptInLinkForVersion1_1()
    {
        formCompletionHelper.ClickElement(AssociateProjectManagerOptInLinkForVersion1_1);
        return new ConfirmOptInForAssociateProjectManagerPage(context);
    }
}