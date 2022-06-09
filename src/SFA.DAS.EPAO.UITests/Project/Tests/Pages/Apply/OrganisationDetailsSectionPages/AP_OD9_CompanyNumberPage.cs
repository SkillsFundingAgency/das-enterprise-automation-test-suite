namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD9_CompanyNumberPage : EPAO_BasePage
{
    protected override string PageTitle => "Do you have a company number?";

    #region Locators
    private static By CompanyNumberTextbox => By.Id("CD-17.1");
    #endregion

    public AP_OD9_CompanyNumberPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD10_DirectorDetailsPage EnterNumberAndContinueInCompanyNumberPage()
    {
        SelectRadioOptionByForAttribute("CD-17");
        formCompletionHelper.EnterText(CompanyNumberTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomNumber(8));
        Continue();
        return new(context);
    }
}
