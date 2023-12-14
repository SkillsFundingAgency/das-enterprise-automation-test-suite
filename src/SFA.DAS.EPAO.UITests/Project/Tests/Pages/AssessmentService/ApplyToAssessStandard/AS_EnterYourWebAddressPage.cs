namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_EnterYourWebAddressPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Enter your web address";

    public AS_EnterYourWebAddressPage(ScenarioContext context) : base(context) { }

    public AS_ApplyToStandardPage EnterWebAddress()
    {
        formCompletionHelper.EnterText(InputText, standardDataHelper.RandomWebsiteAddress);
        Continue();
        return new(context);
    }

    public AS_ApplyToStandardPage NHEI_EnterWebAddress()
    {
        formCompletionHelper.EnterText(InputText, standardDataHelper.RandomWebsiteAddress);
        Continue();
        return new(context);
    }
}