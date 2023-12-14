namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class CancelStandardStepsHelper(ScenarioContext context)
{
    public void CancelYourStandard()
    {
        AP_ApplicationOverviewPage _aP_ApplicationOverviewPage = new(context);

        _aP_ApplicationOverviewPage.ClickToCancelYourStandardApplication()
            .SelectYesToCancelStandardApplication()
            .ClickApplyForAStandardLink();
    }
}