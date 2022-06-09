namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.AuthoriserDetailsSubSection;

public class AP_DAD_1_AuthoriserDetailsPage : EPAO_BasePage
{
    protected override string PageTitle => "Authoriser details";

    #region Locators
    private static By NameTextbox => By.Id("W_DEL-01");
    private static By JobTitleTextbox => By.Id("W_DEL-02");
    #endregion

    public AP_DAD_1_AuthoriserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_DME_1_CriminalConvictionsPage EnterDetailsAndContinueInAuthoriserDetailsPagePage()
    {
        formCompletionHelper.EnterText(NameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(20));
        formCompletionHelper.EnterText(JobTitleTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(10));
        Continue();
        return new AP_DME_1_CriminalConvictionsPage(context);
    }
}
