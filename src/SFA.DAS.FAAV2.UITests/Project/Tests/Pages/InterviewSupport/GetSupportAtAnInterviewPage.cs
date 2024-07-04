namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages.InterviewSupport;

public class GetSupportAtAnInterviewPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Get support at an interview";

    protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");
}
