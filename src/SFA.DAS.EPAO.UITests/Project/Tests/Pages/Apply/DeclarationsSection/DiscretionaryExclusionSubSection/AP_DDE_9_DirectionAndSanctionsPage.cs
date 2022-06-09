namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection;

public class AP_DDE_9_DirectionAndSanctionsPage : EPAO_BasePage
{
    protected override string PageTitle => "Direction and sanctions";

    public AP_DDE_9_DirectionAndSanctionsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DDE_10_RepaymentOfPublicMoneyPage SelectNoOptionAndContinueInDirectionAndSanctionsPage()
    {
        SelectRadioOptionByForAttribute("A_DEL-27_1");
        Continue();
        return new(context);
    }
}
