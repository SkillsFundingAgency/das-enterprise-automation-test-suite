using SFA.DAS.Login.Service.Project.Tests.Pages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.StubPages;

public class StubYouHaveSignedInAssessorPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : StubYouHaveSignedInBasePage(context, username, idOrUserRef, newUser)
{

    protected override By MainContent => By.CssSelector("[id='estimate-start-transfer']");

    protected override By ContinueButton => By.CssSelector("[id='estimate-start-transfer'] a.govuk-button");

    public new void Continue() => base.Continue();
}
