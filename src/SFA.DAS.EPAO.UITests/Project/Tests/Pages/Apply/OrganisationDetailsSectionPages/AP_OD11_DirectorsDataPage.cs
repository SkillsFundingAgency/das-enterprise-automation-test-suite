namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD11_DirectorsDataPage : EPAO_BasePage
{
    protected override string PageTitle => "Directors data";

    public AP_OD11_DirectorsDataPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD_12_RegisteredCharityPage SelectNoOptionAndContinueInDirectorsDataPage()
    {
        SelectRadioOptionByForAttribute("CD-22_1");
        Continue();
        return new(context);
    }
}
