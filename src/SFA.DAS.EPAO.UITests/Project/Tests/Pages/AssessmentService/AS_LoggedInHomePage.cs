using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApprovedStandardsAndVersions;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_LoggedInHomePage(ScenarioContext context) : EPAO_BasePage(context)
{
    protected override string PageTitle => ""; //There is NO Title on this page

    #region Locators
    private static By RecordAGradeLink => By.Id("Record a grade");
    private static By CompletedAssessmentsTopMenuLink => By.Id("Completed assessments");
    private static By OrganisationDetailsTopMenuLink => By.LinkText("Organisation details");
    private static By WithdrawFromAStandardLink => By.LinkText("Withdraw from a standard");
    private static By WithdrawFromTheRegisterLink => By.LinkText("Withdraw from the register");
    private static By ManageUsersLink => By.LinkText("Manage users");
    private static By HomeTopMenuLink => By.Id("Home");
    private static By SignedInUserNameText => By.CssSelector(".das-user-panel__content");
    private static By SignOutLink => By.XPath("//a[@href='/Account/SignOut']");
    private static By ApplyToAssessStandardLink => By.CssSelector("a[href='/ApplyToAssessStandard']");
    private static By ApprovedStandardsAndVersions => By.CssSelector("a[href='/OrganisationStandards']");

    #endregion

    public AS_ApplyToAssessStandardPage ApplyToAssessStandard()
    {
        formCompletionHelper.Click(ApplyToAssessStandardLink);
        return new(context);
    }

    public ApprovedStandardsAndVersionsLandingPage ApprovedStandardAndVersions()
    {
        formCompletionHelper.Click(ApprovedStandardsAndVersions);
        return new(context);
    }

    public AS_RecordAGradePage GoToRecordAGradePage()
    {
        formCompletionHelper.Click(RecordAGradeLink);
        return new(context);
    }

    public AS_CompletedAssessmentsPage ClickCompletedAssessmentsLink()
    {
        formCompletionHelper.Click(CompletedAssessmentsTopMenuLink);
        return new(context);
    }

    public void ClickOrganisationDetailsTopMenuLink()
    {
        formCompletionHelper.Click(OrganisationDetailsTopMenuLink);
    }

    public AS_UsersPage ClickManageUsersLink()
    {
        formCompletionHelper.Click(ManageUsersLink);
        return new(context);
    }

    public AS_LoggedInHomePage ClickHomeTopMenuLink()
    {
        formCompletionHelper.Click(HomeTopMenuLink);
        return this;
    }

    public bool VerifySignedInUserName(string expectedText) => pageInteractionHelper.VerifyText(SignedInUserNameText, expectedText);

    public AS_SignedOutPage ClickSignOutLink()
    {
        formCompletionHelper.Click(SignOutLink);
        return new(context);
    }
    public AS_WithdrawFromAStandardOrTheRegisterPage ClickWithdrawFromAStandardLink()
    {
        formCompletionHelper.Click(WithdrawFromAStandardLink);
        return new(context);
    }

    public AS_WithdrawFromAStandardOrTheRegisterPage ClickWithdrawFromTheRegisterLink()
    {
        formCompletionHelper.Click(WithdrawFromTheRegisterLink);
        return new(context);
    }
}
