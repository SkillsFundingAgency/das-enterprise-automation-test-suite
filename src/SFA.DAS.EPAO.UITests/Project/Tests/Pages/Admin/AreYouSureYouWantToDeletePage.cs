namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class AreYouSureYouWantToDeletePage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Are you sure you want to delete";

    protected override By PageHeader => By.CssSelector(".govuk-heading-l");

    public AreYouSureYouWantToDeletePage(ScenarioContext context) : base(context) => VerifyPage();

    public AuditDetailsPage ClickYesAndContinue()
    {
        SelectRadioOptionByText("Yes");
        Continue();
        return new(context);
    }
}