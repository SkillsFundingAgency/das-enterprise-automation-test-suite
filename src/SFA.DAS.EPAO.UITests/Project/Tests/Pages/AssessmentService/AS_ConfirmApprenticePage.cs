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

        return new(context);
    }

    public AS_ConfirmApprenticePage ViewCertificateHistory()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ViewCertificateHistorySelector));

        return new(context);
    }

    public AS_WhichVersionPage GoToWhichVersionPage(bool hasMultiStandards)
    {
        SelectStandard(hasMultiStandards);

        return new(context);
    }

    public AS_WhichLearningOptionPage GoToWhichLearningOptionPage(bool hasMultiStandards)
    {
        SelectStandard(hasMultiStandards);

        return new(context);
    }

    public AS_DeclarationPage GoToDeclarationPage(bool hasMultiStandards)
    {
        SelectStandard(hasMultiStandards);

        return new(context);
    }

    public AS_DeclarationPage ConfirmAndContinue()
    {
        Continue();
        return new(context);
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