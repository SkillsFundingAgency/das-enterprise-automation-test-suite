namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class CancelStandardStepsHelper
{
    private readonly ScenarioContext _context;

    public CancelStandardStepsHelper(ScenarioContext context) => _context = context;

    public void CancelYourStandard()
    {
        AP_ApplicationOverviewPage _aP_ApplicationOverviewPage = new AP_ApplicationOverviewPage(_context);

        _aP_ApplicationOverviewPage.ClickToCancelYourStandardApplication()
            .SelectYesToCancelStandardApplication()
            .ClickApplyForAStandardLink();
    }
}