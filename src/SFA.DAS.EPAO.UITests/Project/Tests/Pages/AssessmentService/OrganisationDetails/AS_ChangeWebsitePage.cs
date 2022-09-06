namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;

public class AS_ChangeWebsitePage : EPAO_BasePage
{
    protected override string PageTitle => "Change website address";

    #region Locators
    private static By WebsiteAddressTextBox => By.Id("WebsiteLink");
    #endregion

    public AS_ChangeWebsitePage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ConfirmWebsiteAddressPage EnterRandomWebsiteAddressAndClickUpdate()
    {
        formCompletionHelper.EnterText(WebsiteAddressTextBox, ePAOAssesmentServiceDataHelper.RandomWebsiteAddress);
        Continue();
        return new(context);
    }
}

public class AS_ConfirmWebsiteAddressPage : EPAO_BasePage
{
    protected override string PageTitle => "Confirm website address";

    public AS_ConfirmWebsiteAddressPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WebsiteAddressUpdatedPage ClickConfirmButtonInConfirmWebsiteAddressPage()
    {
        Continue();
        return new(context);
    }
}

public class AS_WebsiteAddressUpdatedPage : AS_ChangeOrgDetailsBasePage
{
    protected override string PageTitle => "Website address updated";

    public AS_WebsiteAddressUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
}