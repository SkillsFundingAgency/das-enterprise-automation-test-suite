namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public partial class MyAccountTransferFundingPage : RegistrationBasePage
{
    protected override string PageTitle => "Choose the account you want to use to apply for funding";

    public MyAccountTransferFundingPage(ScenarioContext context) : base(context) => VerifyPage();
}