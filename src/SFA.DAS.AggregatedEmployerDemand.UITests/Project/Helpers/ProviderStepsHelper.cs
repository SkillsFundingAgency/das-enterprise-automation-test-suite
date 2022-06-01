using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;

public class ProviderStepsHelper
{
    private readonly ScenarioContext _context;

    public ProviderStepsHelper(ScenarioContext context) => _context = context;

    internal AedProviderHomePage GoToProviderHomePagePage(ProviderLoginUser login, bool newTab = true)
    {
        new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(login, newTab);

        return new AedProviderHomePage(_context);
    }

    public WhichEmployersAreYouInterestedInPage GoToWhichEmployersAreYouInterestedInPage() => new FindEmployersThatNeedATrainingProviderPage(_context).ViewWhichEmployerNeedsATrainingProvider();

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