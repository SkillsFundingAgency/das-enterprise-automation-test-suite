namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class EmailVerificationPage : AedBasePage
{
    protected override string PageTitle => "Click the link we've sent to";

    protected override bool TakeFullScreenShot => false;

    public EmailVerificationPage(ScenarioContext context) : base(context) { }
}
