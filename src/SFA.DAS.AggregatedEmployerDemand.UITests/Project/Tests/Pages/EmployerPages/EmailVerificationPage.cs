namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class EmailVerificationPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "Click the link we've sent to";

    protected override bool TakeFullScreenShot => false;
}
