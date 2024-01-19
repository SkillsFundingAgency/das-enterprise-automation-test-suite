namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_IntendToOutsourcePage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Do you intend to outsource any of your end-point assessments?";

    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

    public AS_EngageWithEmployersPage EnterIntendToOutsource()
    {
        SelectAndContinue("No");
        return new(context);
    }

    public AS_EngageWithEmployersPage NHEI_EnterIntendToOutsource()
    {
        SelectAndContinue("No");
        return new(context);
    }
}