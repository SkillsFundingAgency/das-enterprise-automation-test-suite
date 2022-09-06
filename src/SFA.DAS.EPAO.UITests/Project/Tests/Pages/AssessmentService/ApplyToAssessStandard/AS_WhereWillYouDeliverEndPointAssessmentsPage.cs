namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_WhereWillYouDeliverEndPointAssessmentsPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Where will you deliver end-point assessments?";

    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

    protected static By DeliveryAreas => By.CssSelector(".govuk-checkboxes__input");

    public AS_WhereWillYouDeliverEndPointAssessmentsPage(ScenarioContext context) : base(context) { }

    public AS_ChooseDayPage ChooseLocation()
    {
        ClickRandomElement(DeliveryAreas);
        Continue();
        return new(context);
    }
    
    public AS_ChooseDayPage NHEIChooseLocation()
    {
        ClickRandomElement(DeliveryAreas);
        Continue();
        return new(context);
    }
}