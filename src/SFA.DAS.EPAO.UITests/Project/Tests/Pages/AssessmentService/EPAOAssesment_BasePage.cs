namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public abstract class EPAOAssesment_BasePage(ScenarioContext context) : EPAO_BasePage(context)
{
    public AS_CheckAndSubmitAssessmentPage ClickBackLink()
    {
        NavigateBack();
        return new(context);
    }

    public AS_CheckAndSubmitAssessmentPage ClickApprenticeBackLink()
    {
        NavigateBack();
        return new(context);
    }
}
