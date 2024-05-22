using System;

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

    protected void SearchVacancyInFAA()
    {
        var vacancyRef = objectContext.GetVacancyReference();

        var uri = new Uri(new Uri(UrlConfig.FAA_BaseUrl), $"vacancies/VAC{vacancyRef}");

        tabHelper.GoToUrl(uri.AbsoluteUri);
    }
}

public class FAASignedOutLandingpage(ScenarioContext context) : FAALandingPage(context)
{
    private static By SignIn => By.CssSelector("a[href*='/Service/signin?']");

    public StubSignInFAAPage GoToSignInPage()
    {
        formCompletionHelper.Click(SignIn);
        return new StubSignInFAAPage(context);
    }
}


public abstract class FAALandingPage(ScenarioContext context) : FAABasePage(context)
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

public class FAASignedInLandingBasePage(ScenarioContext context) : FAALandingPage(context)
{
    private static By SignOut => By.CssSelector("a[href*='/Service/signout']");

    private static By SearchHeader => By.CssSelector("[id='service-header__nav'] a[href='/search-results']");

    private static By ApplicaitonsHeader => By.CssSelector("[id='service-header__nav'] a[href='/applications']");
}

public class FAASearchApprenticeLandingPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    public FAA_ApprenticeSummaryPage SearchByReferenceNumber()
    {
        SearchVacancyInFAA();
        return new FAA_ApprenticeSummaryPage(context);
    }
}

public class FAA_ApprenticeSummaryPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".faa-vacancy__title");

    protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

    protected override string AccessibilityPageTitle => "FAA vacancy title page";

    private static By ApplyButton => By.CssSelector("[id='main-content'] button.govuk-button");

    public FAA_ApplicationPage Apply()
    {
        formCompletionHelper.Click(ApplyButton);
        return new FAA_ApplicationPage(context);
    }

    public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion()
    {
        pageInteractionHelper.VerifyText(ApplyButton, "Continue your application");
        return this;
    }
}

public partial class FAA_ApplicationPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => $"Apply for {vacancyTitleDataHelper.VacancyTitle}";

}

public partial class FAA_ApplicationPage : FAABasePage
{
    #region Questions
    private static string EducationHistory => "Education history";
    private static string EducationHistory_1 => "School, college and university qualifications";
    private static string EducationHistory_2 => "Training courses";
    
    private static string WorkHistory => "Work history";
    private static string WorkHistory_1 => "Jobs";
    private static string WorkHistory_2 => "Volunteering and work experience";
    
    private static string ApplicationQuestions => "Application questions";
    private static string ApplicationQuestions_1 => "What are your skills and strengths?";
    private static string ApplicationQuestions_2 => "What interests you about this apprenticeship?";

    private static string InterviewAdjustments => "Interview adjustments";
    private static string InterviewAdjustments_1 => "Application permissions and checks";

    #endregion
}