namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_CheckAndSubmitAssessmentPage : EPAOAssesment_BasePage
{
    protected override string PageTitle => "Check and submit the assessment details";

    #region Locators
    private static By GradeChangeLink => By.XPath("//a[@href='/certificate/grade?redirecttocheck=true']");
    private static By OptionChangeLink => By.XPath("//a[@href='/certificate/option?redirecttocheck=true']");
    private static By AchievementDateChangeLink => By.XPath("//a[@href='/certificate/date?redirecttocheck=true']");
    private static By NameChangeLink => By.XPath("//a[@href='/certificate/sendto?redirecttocheck=true']");
    private static By CertificateReceiverLink => By.XPath("//a[@href='/certificate/sendto?redirecttocheck=true']");
    private static By DepartmentChangeLink => By.XPath("//dt[contains(text(), 'Department')]/../dd/a");
    private static By OrganisationChangeLink => By.XPath("//dt[contains(text(), 'Organisation')]/../dd/a");
    private static By AddressChangeLink => By.XPath("//a[@href='/certificate/address/enter?redirecttocheck=true']");
    #endregion

    public AS_CheckAndSubmitAssessmentPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_AssessmentRecordedPage ClickContinueInCheckAndSubmitAssessmentPage()
    {
        Continue();
        return new AS_AssessmentRecordedPage(context);
    }

    public AS_WhatGradePage ClickGradeChangeLink()
    {
        formCompletionHelper.ClickElement(GradeChangeLink);
        return new AS_WhatGradePage(context);
    }

    public AS_WhichLearningOptionPage ClickOptionChangeLink()
    {
        formCompletionHelper.ClickElement(OptionChangeLink);
        return new AS_WhichLearningOptionPage(context);
    }

    public AS_AchievementDatePage ClickAchievementDateChangeLink()
    {
        formCompletionHelper.ClickElement(AchievementDateChangeLink);
        return new AS_AchievementDatePage(context);
    }

    public AS_RecipientNamePage ClickNameChangeLink()
    {
        formCompletionHelper.ClickElement(NameChangeLink);
        return new AS_RecipientNamePage(context);
    }

    public AS_WhoWouldYouLikeUsToSendTheCertificateToPage ClickCertificateReceiverLink()
    {
        formCompletionHelper.ClickElement(CertificateReceiverLink);
        return new AS_WhoWouldYouLikeUsToSendTheCertificateToPage(context);
    }
    public AS_RecipientNamePage ClickDepartmentChangeLink()
    {
        formCompletionHelper.ClickElement(DepartmentChangeLink);
        return new AS_RecipientNamePage(context);
    }

    public AS_AddRecipientsDetailsPage ClickDepartmentChangeLinkForEmployerJourney()
    {
        formCompletionHelper.ClickElement(DepartmentChangeLink);
        return new AS_AddRecipientsDetailsPage(context);
    }

    public AS_EditEmployerAddress ClickOrganisationChangeLink()
    {
        formCompletionHelper.ClickElement(OrganisationChangeLink);
        return new AS_EditEmployerAddress(context);
    }

    public AS_EditEmployerAddress ClickCertificateAddressChangeLink()
    {
        formCompletionHelper.ClickElement(AddressChangeLink);
        return new AS_EditEmployerAddress(context);
    }

    public AS_SearchEmployerAddressPage ClickCertificateAddressChangeLinkvForApprenticeJourney()
    {
        formCompletionHelper.ClickElement(AddressChangeLink);
        return new AS_SearchEmployerAddressPage(context);
    }

    public AS_SearchEmployerOrAddressPage ClickCertificateAddressChangeLinkForEmployerJourney()
    {
        formCompletionHelper.ClickElement(AddressChangeLink);
        return new AS_SearchEmployerOrAddressPage(context);
    }
}
