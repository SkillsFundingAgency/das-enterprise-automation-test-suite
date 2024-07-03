using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages;

public abstract class FAABasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly FAADataHelper faaDataHelper;
    protected readonly AdvertDataHelper advertDataHelper;
    protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
    #endregion

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

    protected virtual By SubmitSectionButton => By.CssSelector("button.govuk-button[id='submit-button']");

    protected FAABasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();

        faaDataHelper = context.Get<FAADataHelper>();

        advertDataHelper = context.GetValue<AdvertDataHelper>();

        if (verifyPage) VerifyPage();
    }

    public FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionCompleted");

        formCompletionHelper.Click(SubmitSectionButton);

        return new(context);
    }

    protected void SearchVacancyInFAA()
    {
        var vacancyRef = objectContext.GetVacancyReference();

        var uri = new Uri(new Uri(UrlConfig.FAAV2_BaseUrl), $"apprenticeship/VAC{vacancyRef}");

        tabHelper.GoToUrl(uri.AbsoluteUri);
    }
}

public class CheckFAASignedOutLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => FAASignedOutLandingpage.FAASignedOutPageTitle;

    protected override By Identifier => FAASignedOutLandingpage.FAASignedOutPageHeader;
}

public class FAASignedOutLandingpage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => FAASignedOutPageHeader;

    protected override string PageTitle => FAASignedOutPageTitle;

    public static string FAASignedOutPageTitle => "Sign in";

    public static By FAASignedOutPageHeader => By.CssSelector(".govuk-header");

    private static By SignIn => By.CssSelector("a[href*='signin?']");

    public StubSignInFAAPage GoToSignInPage()
    {
        formCompletionHelper.Click(SignIn);

        return new StubSignInFAAPage(context);
    }
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

public class FAASignedInLandingBasePage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".one-login-header");

    protected override string PageTitle => "Sign out";

    private static By SearchHeader => By.CssSelector("[id='service-header__nav'] a[href='/apprenticeships']");

    private static By ApplicationsHeader => By.CssSelector("[id='service-header__nav'] a[href='/applications']");

    public FAA_ApplicationsPage GoToApplications()
    {
        formCompletionHelper.Click(ApplicationsHeader);

        return new(context);
    }

    public FAASearchApprenticeLandingPage GoToSearch()
    {
        formCompletionHelper.Click(SearchHeader);

        return new(context);
    }

    public FAA_ApprenticeSummaryPage SearchByReferenceNumber()
    {
        SearchVacancyInFAA();
        return new FAA_ApprenticeSummaryPage(context);
    }
}

public class FAA_ApplicationsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Your applications";

    private static By SuccessfulLink => By.CssSelector("a[href='/applications?tab=Successful']");

    private static By UnsuccessfulLink => By.CssSelector("a[href='/applications?tab=Unsuccessful']");

    private static By SearchResultItem => By.CssSelector(".das-search-results__list-item");

    private static By ViewApplicationLink => By.CssSelector("a[href*='view']");

    public FAA_SuccessfulApplicationPage OpenSuccessfulApplicationPage()
    {
        formCompletionHelper.Click(SuccessfulLink);

        return new(context);
    }

    public FAA_UnSuccessfulApplicationPage OpenUnSuccessfulApplicationPage()
    {
        formCompletionHelper.Click(UnsuccessfulLink);

        return new(context);
    }

    public void ViewApplication()
    {
        pageInteractionHelper.FindElements(SearchResultItem).Single(x => x.Text.ContainsCompareCaseInsensitive(vacancyTitleDataHelper.VacancyTitle)).FindElement(ViewApplicationLink).Click();
    }
}

public class FAASearchApprenticeLandingPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override string PageTitle => "Search apprenticeships";


}

public class FAA_ApprenticeSummaryPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".faa-vacancy__title");

    protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

    protected override string AccessibilityPageTitle => "FAA vacancy title page";

    private static By ApplyButton => By.CssSelector("[id='main-content'] button.govuk-button");

    private static By ViewSubmittedApplicationLink => By.CssSelector("a[href*='Submitted']");


    public FAA_ApplicationOverviewPage Apply()
    {
        formCompletionHelper.Click(ApplyButton);
        return new FAA_ApplicationOverviewPage(context);
    }

    public FAA_SubmittedApplicationPage ViewSubmittedApplications()
    {
        formCompletionHelper.Click(ViewSubmittedApplicationLink);
        return new FAA_SubmittedApplicationPage(context);
    }


    public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion()
    {
        pageInteractionHelper.VerifyText(ApplyButton, "Continue your application");
        return this;
    }
}

public class FAA_SubmittedApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => "Submitted";
}

public class FAA_SuccessfulApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => "Successful";
}

public class FAA_UnSuccessfulApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => "Unsuccessful";
}
