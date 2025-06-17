namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.ApplicationAccuracySubSection;

public class AP_DAA_3_AgreementOnTheRegisterPage : EPAOApply_BasePage
{
    protected override string PageTitle => "Agreement to appear on the register";

    public AP_DAA_3_AgreementOnTheRegisterPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DeclarationsBasePage SelectYesOptionAndContinueInAgreementOnTheRegisterPage()
    {
        SelectRadioOptionByForAttribute("A_DEL-30");
        Continue();
        return new(context);
    }
}
