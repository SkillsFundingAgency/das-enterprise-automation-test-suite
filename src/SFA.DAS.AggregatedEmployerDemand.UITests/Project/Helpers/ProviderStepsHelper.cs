using SFA.DAS.ProviderLogin.Service.Project;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;

public class ProviderStepsHelper(ScenarioContext context)
{
    internal AedProviderHomePage GoToProviderHomePagePage(ProviderLoginUser login, bool newTab = true)
    {
        new ProviderHomePageStepsHelper(context).GoToProviderHomePage(login, newTab);

        return new AedProviderHomePage(context);
    }

    public WhichEmployersAreYouInterestedInPage GoToWhichEmployersAreYouInterestedInPage() => new FindEmployersThatNeedATrainingProviderPage(context).ViewWhichEmployerNeedsATrainingProvider();

    public static WeveSharedYourContactDetailsWithEmployersPage ConfirmEditedProviderContactDetailsAndSubmit(ConfirmProvidersContactDetailsPage page) =>
        page.ContinueToProviderCheckYourAnswersPage()
        .ContinueToWeveSharedYourContactDetailsWithEmployersPage();

    public static WhichEmployersAreYouInterestedInPage NavigateBacktoWhichEmployersAreYouInterestedInPage(ConfirmProvidersContactDetailsPage page)
    {
        return page.ContinueToProviderCheckYourAnswersPage().BackToProvidersContactDetailsPage()
            .BackToEditProvidersContactDetailsPage()
            .BackToWhichEmployersAreYouInterestedInPage()
            .BackToFindEmployersThatNeedATrainingProviderPage()
            .ViewWhichEmployerNeedsATrainingProvider();
    }

    public static WeveSharedYourContactDetailsWithEmployersPage SubmitProviderLocationDetails(ConfirmProvidersContactDetailsPage page)
    {
        return page.ContinueToProviderCheckYourAnswersPage()
            .ChangeProviderLocationDetails()
            .CheckAndContinueWithfirstEmployerCheckboxAfterChange()
            .ContinueToProviderCheckYourAnswersPage()
            .ContinueToWeveSharedYourContactDetailsWithEmployersPage();
    }
}