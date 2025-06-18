namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_RecipientNamePage : EPAOAssesment_BasePage
{
    protected override string PageTitle => "What is the recipient's name?";
    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

    public AS_RecipientNamePage(ScenarioContext context) : base(context) => VerifyPage();

}
