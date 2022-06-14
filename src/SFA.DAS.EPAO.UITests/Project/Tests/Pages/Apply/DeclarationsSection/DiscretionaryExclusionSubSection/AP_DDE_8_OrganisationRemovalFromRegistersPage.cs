namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection;

public class AP_DDE_8_OrganisationRemovalFromRegistersPage : EPAO_BasePage
{
    protected override string PageTitle => "Organisation removal from registers";

    public AP_DDE_8_OrganisationRemovalFromRegistersPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DDE_9_DirectionAndSanctionsPage SelectNoOptionAndContinueInOrganisationRemovalFromRegistersPage()
    {
        SelectRadioOptionByForAttribute("A_DEL-26_1");
        Continue();
        return new(context);
    }
}
