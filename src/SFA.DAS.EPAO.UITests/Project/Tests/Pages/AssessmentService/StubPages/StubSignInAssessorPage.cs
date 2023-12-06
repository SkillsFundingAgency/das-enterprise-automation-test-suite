using SFA.DAS.Login.Service.Project.Tests.Pages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.StubPages;


public class CheckStubSignInAssessorPage : CheckPageUsingPageTitle
{
    protected override string PageTitle => StubSignInAssessorPage.StubSignInAssessorPageTitle;

    protected override By Identifier => PageHeader;

    public CheckStubSignInAssessorPage(ScenarioContext context) : base(context) { }
}

public class StubSignInAssessorPage : StubSignInBasePage
{
    protected override string PageTitle => StubSignInAssessorPageTitle;

    internal static string StubSignInAssessorPageTitle => "Stub Authentication - Enter sign in details";

    public StubSignInAssessorPage(ScenarioContext context) : base(context) { }

    public StubYouHaveSignedInAssessorPage SubmitValidUserDetails(GovSignUser loginUser)
    {
        var email = loginUser.Username;

        var idOrUserRef = loginUser.IdOrUserRef;

        EnterLoginDetailsAndClickSignIn(email, idOrUserRef);

        return new StubYouHaveSignedInAssessorPage(context, email, idOrUserRef, false);
    }
}