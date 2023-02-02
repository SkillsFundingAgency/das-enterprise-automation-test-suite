using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;

public class AedStepsHelper
{
    private readonly ScenarioContext _context;
    private readonly FATV2StepsHelper _fATV2StepsHelper;
    private readonly TabHelper _tabHelper;
    private readonly string[] tags;

    public AedStepsHelper(ScenarioContext context)
    {
        _context = context;
        tags = _context.ScenarioInfo.Tags;
        _fATV2StepsHelper = new FATV2StepsHelper(_context);
        _tabHelper = context.Get<TabHelper>();
    }

    public void RegisterInterest(int noOfApprentices) => RegisterInterest(noOfApprentices, GetHelpWithFindingATrainingProvider(NavigateToShareYourInterestWithTrainingProvidersPage()));

    public void RegisterInterest(int noOfApprentices, GetHelpWithFindingATrainingProviderPage getHelpWithFindingATrainingProviderPage)
    {
        getHelpWithFindingATrainingProviderPage.EnterValidDetails(noOfApprentices).ConfirmYourAnswers();

        var email = _context.Get<AedDataHelper>().RandomEmail;

        _tabHelper.OpenInNewTab(_context.Get<MailinatorApiHelper>().GetData(email, "https://"));

        new WeveSharedYourInterestWithProviderPage(_context).VerifyContent(email);
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
