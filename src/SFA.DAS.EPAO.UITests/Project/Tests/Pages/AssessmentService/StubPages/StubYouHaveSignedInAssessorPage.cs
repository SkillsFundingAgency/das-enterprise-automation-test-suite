using SFA.DAS.Login.Service.Project.Tests.Pages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.StubPages;

public class StubYouHaveSignedInAssessorPage : StubYouHaveSignedInBasePage
{

    protected override By MainContent => By.CssSelector("[id='estimate-start-transfer']");

    protected override By ContinueButton => By.CssSelector("[id='estimate-start-transfer'] a.govuk-button");

    public StubYouHaveSignedInAssessorPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context, username, idOrUserRef, newUser)
    {

    }

    public new void Continue() => base.Continue();
}
