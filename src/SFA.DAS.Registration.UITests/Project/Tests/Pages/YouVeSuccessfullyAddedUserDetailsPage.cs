namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class YouVeSuccessfullyAddedUserDetailsPage : RegistrationBasePage
{
    protected override string PageTitle { get; }
    protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");


    public YouVeSuccessfullyAddedUserDetailsPage(ScenarioContext context, bool updated = false) : base(context)
    {
        PageTitle = updated ? "You have successfully changed user details" : "You have successfully added user details";
        VerifyPage();
    }

    public CreateYourEmployerAccountPage ClickContinueButtonToAcknowledge()
    {
        Continue();
        return new CreateYourEmployerAccountPage(context);
    }

    public InvitationsPage ClickContinueToInvitationsPage()
    {
        Continue();
        return new InvitationsPage(context);
    }
}
