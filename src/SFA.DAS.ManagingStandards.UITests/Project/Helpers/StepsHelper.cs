namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;
    private readonly TabHelper _tabHelper;
    private readonly FormCompletionHelper formCompletionHelper;
    private readonly ProviderConfig _providerConfig;

    private static By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

    public StepsHelper(ScenarioContext context)
    {
        _context = context;
        _providerConfig = context.GetProviderConfig<ProviderConfig>();
        _tabHelper = _context.Get<TabHelper>();
        formCompletionHelper = _context.Get<FormCompletionHelper>();
    }

    public void NavigateToReviewYourDetails()
    {
        //This is the only way we can naviagate to Managing standards for now,
        //This will change when Dashboard link will be implemented

        _tabHelper.GoToUrl($"{UrlConfig.MS_BaseUrl}{_providerConfig.Ukprn}/review-your-details");
        formCompletionHelper.ClickElement(PireanPreprod);
    }
}
