namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class ManageYourLearnersPage : RegistrationBasePage
{
    protected override string PageTitle => "Manage your learners";

    protected override bool TakeFullScreenShot => false;

    public ManageYourLearnersPage(ScenarioContext context) : base(context) => VerifyPage();

}