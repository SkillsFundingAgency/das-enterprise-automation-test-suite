namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class SearchEmployerEmailPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    private static By EmailSelector => By.CssSelector("input[id='Email']");

    protected override string PageTitle => "Search employer email";

    public EmailAccountFoundPage EnterEmployerEmail()
    {
        return new(context, EnterEmail());
    }

    public EmailAccountNotFoundPage EnterNewEmployerEmail()
    {
        return new(context, EnterEmail());
    }

    public ContactEmployerShutterPage EnterEmployerEmailAndGoToContactEmployer()
    {
        EnterEmail();

        return new(context);
    }

    public InviteSentShutterPage EnterEmployerEmailAndGoToInviteSent()
    {
        EnterEmail();

        return new(context, false);
    }

    private string EnterEmail()
    {
        var email = eprDataHelper.EmployerEmail;

        formCompletionHelper.EnterText(EmailSelector, email);

        Continue();

        return email;
    }

}
