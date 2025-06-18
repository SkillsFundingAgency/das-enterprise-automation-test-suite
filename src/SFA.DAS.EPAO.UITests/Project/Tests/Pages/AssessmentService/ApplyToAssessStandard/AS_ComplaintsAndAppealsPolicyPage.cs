namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ComplaintsAndAppealsPolicyPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Complaints and appeals policy";

    public AS_FairAccessPage UploadComplaintsPolicy()
    {
        UploadFile();
        return new(context);
    }

    public AS_FairAccessPage NHEI_UploadComplaintsPolicy()
    {
        UploadFile();
        return new(context);
    }
}