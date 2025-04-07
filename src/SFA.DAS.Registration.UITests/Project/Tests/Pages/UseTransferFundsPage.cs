namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;
public class UseTransferFundsPage : RegistrationBasePage
{
    protected override string PageTitle => "Use transfer funds from";
    public UseTransferFundsPage(ScenarioContext context) : base(context) => VerifyPage();
}