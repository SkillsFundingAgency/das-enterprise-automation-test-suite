namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_WhichVersionPage : EPAO_BasePage
{
    protected override string PageTitle => "Which version";

    public AS_WhichVersionPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhichLearningOptionPage ClickConfirmInConfirmVersionPage()
    {
        SelectRadioOptionByText("Version 1.0");
        Continue();
        return new(context);
    }

    public AS_DeclarationPage ClickConfirmInConfirmVersionPageNoOption()
    {
        SelectRadioOptionByText("Version 1.0");
        Continue();
        return new(context);
    }
}