namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection;

public class AP_DDE_12_LegalDisputePage : EPAO_BasePage
{
    protected override string PageTitle => "Legal dispute";

    public AP_DDE_12_LegalDisputePage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DAA_1_FalseDeclarationsPage SelectNoOptionAndContinueInLegalDisputePage()
    {
        SelectRadioOptionByForAttribute("A_DEL-30_1");
        Continue();
        return new(context);
    }
}
