using SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASignedInLandingBasePage(ScenarioContext context, bool verifyPage = true) : FAABasePage(context, verifyPage)
{
    protected override By PageHeader => By.CssSelector(".one-login-header");

    protected override string PageTitle => "Sign out";

    private static By SearchHeader => By.CssSelector("[id='service-header__nav'] a[href='/apprenticeships']");

    private static By ApplicationsHeader => By.CssSelector("[id='service-header__nav'] a[href='/applications']");
    private static By FirstName => By.Id("FirstName");
    private static By LastName => By.Id("LastName");


    private static By VacancyName => By.CssSelector("span[itemprop='title']");
    private static By SavedVacancyLink => By.CssSelector(".govuk-link.govuk-link--no-visited-state");

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
        SearchUsingVacancyTitle();

        GoToVacancyInFAA();

        return new FAA_ApprenticeSummaryPage(context);
    }

    public FAASearchResultPage SearchAndSaveVacancyByReferenceNumber()
    {
        SearchUsingVacancyTitle();

        return new FAASearchResultPage(context);
    }

    public DateOfBirthPage EnterApprenticeFirstAndLastName()
    {
        Continue();

        formCompletionHelper.EnterText(FirstName, RandomDataGenerator.GenerateRandomAlphabeticString(10));
        formCompletionHelper.EnterText(LastName, RandomDataGenerator.GenerateRandomAlphabeticString(10));

        Continue();

        return new(context);
    }
    public FAASearchApprenticeLandingPage CompleteApprenticeSignUpDetails()
    {

        EnterApprenticeFirstAndLastName().EnterApprenticeDateOfBirth().EnterApprenticePostCode().EnterApprenticeTelephoneNumber().SelectRemindersNotification().ClickCreateYourAccountConfirmation();
        return new(context); 
    }
}
   