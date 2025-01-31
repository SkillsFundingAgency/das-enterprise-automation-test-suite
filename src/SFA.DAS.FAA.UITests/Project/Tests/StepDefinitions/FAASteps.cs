using SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAASteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [Then(@"the status of the Application is shown as '(successful|unsuccessful)' in FAA")]
    public void ThenTheStatusOfTheApplicationIsShownAsInFAA(string expectedStatus)
    {
        _faaStepsHelper.VerifyApplicationStatus(expectedStatus == "successful");
    }
    
    [Then(@"the applicant can save on vacancy details page before applying for the vacancy")]
    public void ThenTheApplicantCanSaveBeforeApplyingForTheVacancy() => _faaStepsHelper.GoToVacancyDetailsPageThenSaveBeforeApplying();

    [Then(@"the applicant can save vacancy on search results page before applying for the vacancy")]
    public void ThenTheApplicantCanSaveVacancyOnSearchResultsPageBeforeApplyingForTheVacancy() => _faaStepsHelper.GoToSearchResultsPagePageAndSaveBeforeApplying();

    [Then("the Applicant can withdraw the application")]
    public void ThenTheApplicantCanWithdrawTheApplication() => _faaStepsHelper.GoToYourApplicationsPageAndWithdrawAnApplication();

    [Then("the apprentice attempts to delete their account they are notified of application withdrawal")]
    public void WhenTheApprenticeAttemptsToDeleteTheirAccountTheyAreNotifiedOfApplicationWithdrawal()
    {
        new SettingPage(context).DeleteMyAccount().ContinueToDeleteMyAccounWithApplication().WithdrawBeforeDeletingMyAccount().ConfirmDeleteMyAccount().VerifyNotification();
    }


}