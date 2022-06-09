namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.ApplicationAccuracySubSection;

public class AP_DAA_1_FalseDeclarationsPage : EPAO_BasePage
{
    protected override string PageTitle => "False declarations";

    public AP_DAA_1_FalseDeclarationsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DAA_2_AccurateRepresentationPage SelectYesOptionAndContinueInFalseDeclarationsPage()
    {
        SelectRadioOptionByForAttribute("A_DEL-28");
        Continue();
        return new AP_DAA_2_AccurateRepresentationPage(context);
    }
}
