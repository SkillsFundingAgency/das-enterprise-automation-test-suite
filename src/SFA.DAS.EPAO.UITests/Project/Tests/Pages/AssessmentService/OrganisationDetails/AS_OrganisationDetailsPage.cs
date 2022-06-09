namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;

public class AS_OrganisationDetailsPage : EPAO_BasePage
{
    protected override string PageTitle => "Organisation details";

    public AS_OrganisationDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ChangeContactNamePage ClickContactNameChangeLink()
    {
        ClickLinkByHref("SelectOrChangeContactName");
        return new AS_ChangeContactNamePage(context);
    }

    public AS_ChangePhoneNumberPage ClickPhoneNumberChangeLink()
    {
        ClickLinkByHref("ChangePhoneNumber");
        return new AS_ChangePhoneNumberPage(context);
    }

    public AS_ChangeAddressPage ClickAddressChangeLink()
    {
        ClickLinkByHref("ChangeAddress");
        return new AS_ChangeAddressPage(context);
    }

    public AS_ChangeEmailPage ClickEmailChangeLink()
    {
        ClickLinkByHref("ChangeEmail");
        return new AS_ChangeEmailPage(context);
    }

    public AS_ChangeWebsitePage ClickWebsiteChangeLink()
    {
        ClickLinkByHref("ChangeWebsite");
        return new AS_ChangeWebsitePage(context);
    }

    private void ClickLinkByHref(string href) => formCompletionHelper.ClickElement(pageInteractionHelper.GetLinkByHref(href));
}

public class AS_ChangeOrganisationDetailsPage : EPAO_BasePage
{
    protected override string PageTitle => "Change organisation details";

    public AS_ChangeOrganisationDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_OrganisationDetailsPage ClickAccessButton()
    {
        Continue();
        return new AS_OrganisationDetailsPage(context);
    }
}
