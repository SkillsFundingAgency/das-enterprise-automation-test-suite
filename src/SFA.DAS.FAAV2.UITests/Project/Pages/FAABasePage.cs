using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAAV2.UITests.Project.Pages;

public abstract class FAABasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly FAADataHelper faaDataHelper;
    protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
    #endregion

    protected FAABasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
        faaDataHelper = context.Get<FAADataHelper>();
        if (verifyPage) VerifyPage();
    }
}

public class FAASignedOutLandingpage(ScenarioContext context) : FAALandingpage(context)
{
    private static By SignIn => By.CssSelector("a[href*='/Service/signin?']");

    public StubSignInFAAPage GoToSignInPage()
    {
        formCompletionHelper.Click(SignIn);
        return new StubSignInFAAPage(context);
    }
}


public abstract class FAALandingpage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Search apprenticeships";
}

public class StubSignInFAAPage(ScenarioContext context) : StubSignInBasePage(context)
{
    protected override string PageTitle => StubSignInFAAPageTitle;

    internal static string StubSignInFAAPageTitle => "Stub Authentication - Enter sign in details";

    private static By MobilePhoneInput => By.CssSelector(".govuk-input[id='MobilePhone']");

    public StubYouHaveSignedInFAAPage SubmitValidUserDetails(FAAPortalUser loginUser)
    {
        return GoToStubYouHaveSignedInFAAPage(loginUser.Username, loginUser.IdOrUserRef, loginUser.MobilePhone, false);
    }

    public StubYouHaveSignedInFAAPage CreateAccount(string email) => GoToStubYouHaveSignedInFAAPage(email, email, "0", true);

    private StubYouHaveSignedInFAAPage GoToStubYouHaveSignedInFAAPage(string email, string idOrUserRef, string mobilePhone, bool newUser)
    {
        EnterLoginDetails(email, idOrUserRef);

        formCompletionHelper.EnterText(MobilePhoneInput, mobilePhone);

        ClickSignIn();

        return new StubYouHaveSignedInFAAPage(context, email, idOrUserRef, newUser);
    }
}

public class StubYouHaveSignedInFAAPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : StubYouHaveSignedInBasePage(context, username, idOrUserRef, newUser)
{

    protected override By MainContent => By.CssSelector("[id='estimate-start-transfer']");

    protected override By ContinueButton => By.CssSelector("[id='estimate-start-transfer'] a.govuk-button");

    public new void Continue() => base.Continue();
}

public class FAASignedInLandingBasepage(ScenarioContext context) : FAALandingpage(context)
{
    private static By SignOut => By.CssSelector("a[href*='/Service/signout']");

    private static By SearchHeader => By.CssSelector("[id='service-header__nav'] a[href='/search-results']");

    private static By ApplicaitonsHeader => By.CssSelector("[id='service-header__nav'] a[href='/applications']");
}

public class FAASignedInLandingpage(ScenarioContext context) : FAASignedInLandingBasepage(context)
{

}