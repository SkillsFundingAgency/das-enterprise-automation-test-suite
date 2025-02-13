namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_HaveYouReceivedApprovalFromTheRegulatorPage(ScenarioContext context) : EPAO_BasePage(context)
{
    protected override string PageTitle => "Have you received approval from the regulator?";

    private static By ClickYes => By.XPath("//input[@class='govuk-radios__input'][1]");

    public AS_ApplyToStandardPage SelectYesHaveYouReceivedApprovalFromTheRegulator()
    {
        formCompletionHelper.Click(ClickYes);
        Continue();
        return new(context);
    }

    public AS_ApplicationSubmittedPage Submit()
    {
        Continue();
        return new(context);
    }
}
