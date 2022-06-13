namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;

public class AedStepsHelper
{
    private readonly ScenarioContext _context;
    private readonly FATV2StepsHelper _fATV2StepsHelper;

    public AedStepsHelper(ScenarioContext context)
    {
        _context = context;
        _fATV2StepsHelper = new FATV2StepsHelper(_context);
    }

    public void RegisterInterest(int noOfApprentices) => RegisterInterest(noOfApprentices, GetHelpWithFindingATrainingProvider(NavigateToShareYourInterestWithTrainingProvidersPage()));

    public void RegisterInterest(int noOfApprentices, GetHelpWithFindingATrainingProviderPage getHelpWithFindingATrainingProviderPage)
    {
        getHelpWithFindingATrainingProviderPage.EnterValidDetails(noOfApprentices).ConfirmYourAnswers();

        new MailinatorStepsHelper(_context, _context.Get<AedDataHelper>().RandomEmail).OpenLink("https://");
    }

    public static GetHelpWithFindingATrainingProviderPage GetHelpWithFindingATrainingProvider(AedIndexPage aEDIndexPage) => ClickStartNow(aEDIndexPage.ClickGetHelpWithFindingATrainingProviderLink());

    public GetHelpWithFindingATrainingProviderPage GetHelpWithFindingATrainingProvider() => GetHelpWithFindingATrainingProvider(GoToAedIndexPage());
    
    public static GetHelpWithFindingATrainingProviderPage GetHelpWithFindingATrainingProviderViaShortlistPage(AedIndexPage page) => ClickStartNow(page.ClickShareInterestButton());

    public AedIndexPage NavigateToShareYourInterestWithTrainingProvidersPage()
    {
        _fATV2StepsHelper.ViewProvidersForThisCourse();

        return GoToAedIndexPage();
    }

    public AedIndexPage NavigateToShareYourInterestWithTrainingProvidersPageViaShortlistPage()
    {
        _fATV2StepsHelper.ShortlistATrainingCourseAndNavigateToShortlistPage();

        return GoToAedIndexPage();
    }

    private AedIndexPage GoToAedIndexPage() => new(_context);

    private static GetHelpWithFindingATrainingProviderPage ClickStartNow(ShareYourInterestWithTrainingProvidersPage page) => page.ClickStartNow();
}
