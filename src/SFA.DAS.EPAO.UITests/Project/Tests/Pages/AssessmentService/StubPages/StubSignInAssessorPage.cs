using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.StubPages;


public class CheckStubSignInAssessorPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => StubSignInAssessorPage.StubSignInAssessorPageTitle;

    protected override By Identifier => PageHeader;
}

public class StubSignInAssessorPage(ScenarioContext context) : StubSignInBasePage(context)
{
    protected override string PageTitle => StubSignInAssessorPageTitle;

    internal static string StubSignInAssessorPageTitle => "Stub Authentication - Enter sign in details";

    public StubYouHaveSignedInAssessorPage SubmitValidUserDetails(GovSignUser loginUser)
    {
        return GoToStubYouHaveSignedInAssessorPage(loginUser.Username, loginUser.IdOrUserRef, false);
    }

    public StubYouHaveSignedInAssessorPage CreateAccount(string email) => GoToStubYouHaveSignedInAssessorPage(email, email, true);

    private StubYouHaveSignedInAssessorPage GoToStubYouHaveSignedInAssessorPage(string email, string idOrUserRef, bool newUser)
    {
        EnterLoginDetailsAndClickSignIn(email, idOrUserRef);

        return new StubYouHaveSignedInAssessorPage(context, email, idOrUserRef, newUser);
    }
}