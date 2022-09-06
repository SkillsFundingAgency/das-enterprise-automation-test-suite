namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_EngagementWithTrailblazersAndEmployersPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Engagement with trailblazers and employers";

    public AS_EngagementWithTrailblazersAndEmployersPage(ScenarioContext context) : base(context) { }

    public AS_MembershipProfessionalPage EnterEngagement()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
 
    public AS_MembershipProfessionalPage NHEI_EnterEngagement()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}