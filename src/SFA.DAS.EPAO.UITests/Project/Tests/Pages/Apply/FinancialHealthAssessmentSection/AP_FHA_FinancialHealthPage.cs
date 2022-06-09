namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection;

public class AP_FHA_FinancialHealthPage : EPAOApply_BasePage
{
    protected override string PageTitle => "Financial health";

    public AP_FHA_FinancialHealthPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_FHABasePage UploadFileAndContinueInFinancialHealthPage()
    {
        UploadFile();
        return new AP_FHABasePage(context);
    }
}
