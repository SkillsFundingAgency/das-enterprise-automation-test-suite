namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_RecordAGradePage : EPAO_BasePage
{
    protected override string PageTitle => "Record a grade";

    private readonly EPAOApplySqlDataHelper _ePAOSqlDataHelper;

    #region Locators
    private static By FamilyNameTextBox => By.Name("Surname");
    private static By ULNTextBox => By.Name("Uln");
    private static By FamilyNameMissingErrorText => By.LinkText("Enter the apprentice's family name");
    private static By ULNMissingErrorText => By.LinkText("Enter the apprentice's ULN");
    private static By InvalidUlnErrorText => By.LinkText("The apprentice's ULN should contain exactly 10 numbers");
    #endregion

    public AS_RecordAGradePage(ScenarioContext context) : base(context)
    {
        _ePAOSqlDataHelper = context.Get<EPAOApplySqlDataHelper>();
        VerifyPage();
    }

    public AS_AssesmentAlreadyRecorded GoToAssesmentAlreadyRecordedPage()
    {
        EnterApprenticeDetailsAndContinue(ePAOAdminDataHelper.FamilyName, ePAOAdminDataHelper.LearnerUln);
        return new(context);
    }

    public AS_ConfirmApprenticePage SearchApprentice(bool deleteExistingCertificate, string learnerFamilyName = null, string learnerUln = null)
    {
        if (deleteExistingCertificate)
            _ePAOSqlDataHelper.DeleteCertificate(learnerUln ?? ePAOAdminDataHelper.LearnerUln);

        EnterApprenticeDetailsAndContinue(learnerFamilyName ?? ePAOAdminDataHelper.FamilyName, learnerUln ?? ePAOAdminDataHelper.LearnerUln);

        return new(context);
    }

    public void EnterApprenticeDetailsAndContinue(string familyName, string uln)
    {
        formCompletionHelper.EnterText(FamilyNameTextBox, familyName);
        formCompletionHelper.EnterText(ULNTextBox, uln);
        Continue();
    }

    public void VerifyErrorMessage(string pageTitle) => VerifyElement(PageHeader, pageTitle);

    public bool VerifyFamilyNameMissingErrorText() => pageInteractionHelper.IsElementDisplayed(FamilyNameMissingErrorText);

    public bool VerifyULNMissingErrorText() => pageInteractionHelper.IsElementDisplayed(ULNMissingErrorText);

    public bool VerifyInvalidUlnErrorText() => pageInteractionHelper.IsElementDisplayed(InvalidUlnErrorText);

    public string GetPageTitle() => pageInteractionHelper.GetText(PageHeader);

    public AS_CannotFindApprenticePage EnterApprenticeDetailsForExistingCertificateAndContinue()
    {
        formCompletionHelper.EnterText(FamilyNameTextBox, ePAOAdminDataHelper.FamilyName);
        formCompletionHelper.EnterText(ULNTextBox, ePAOAdminDataHelper.LearnerUlnForExistingCertificate);
        Continue();
        return new(context);
    }
}