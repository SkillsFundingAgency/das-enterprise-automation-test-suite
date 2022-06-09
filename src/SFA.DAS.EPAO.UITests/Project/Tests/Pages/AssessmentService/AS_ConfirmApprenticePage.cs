namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_ConfirmApprenticePage : EPAO_BasePage
{
    protected override string PageTitle => "Confirm this is the correct apprentice";

    protected override By RadioLabels => By.CssSelector(".govuk-radios__label[for*='standard']");

    private static By ViewCertificateHistorySelector => By.CssSelector(".govuk-details__summary-text");

    public AS_ConfirmApprenticePage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_AssesmentAlreadyRecorded GoToAssesmentAlreadyRecordedPage()
    {
        SelectStandard(true);

        return new AS_AssesmentAlreadyRecorded(context);
    }

    public AS_ConfirmApprenticePage ViewCertificateHistory()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ViewCertificateHistorySelector));

        return new AS_ConfirmApprenticePage(context);
    }

    public AS_WhichVersionPage GoToWhichVersionPage(bool hasMultiStandards)
    {
        SelectStandard(hasMultiStandards);

        return new AS_WhichVersionPage(context);
    }

    public AS_WhichLearningOptionPage GoToWhichLearningOptionPage(bool hasMultiStandards)
    {
        SelectStandard(hasMultiStandards);

        return new AS_WhichLearningOptionPage(context);
    }

    public AS_DeclarationPage GoToDeclarationPage(bool hasMultiStandards)
    {
        SelectStandard(hasMultiStandards);

        return new AS_DeclarationPage(context);
    }

    public AS_DeclarationPage ConfirmAndContinue()
    {
        Continue();
        return new AS_DeclarationPage(context);
    }

    private void SelectStandard(bool hasMultiStandards)
    {
        if (hasMultiStandards)
        {
            var standardName = objectContext.GetLearnerStandardName();

            if (string.IsNullOrEmpty(standardName)) SelectRadioOptionByText(pageInteractionHelper.GetText(RadioLabels));

            else SelectRadioOptionByText(standardName);

        }

        Continue();
    }
}