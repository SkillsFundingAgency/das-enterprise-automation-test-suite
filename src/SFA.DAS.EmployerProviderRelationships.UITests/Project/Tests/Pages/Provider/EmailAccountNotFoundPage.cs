namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class EmailAccountNotFoundPage : ProviderRelationshipsBasePage
{
    private static By GovBody => By.CssSelector(".govuk-body");

    protected override string PageTitle => "Search employer details";

    private static By PayeSelector => By.CssSelector("input#Paye");

    private static By AornSelector => By.CssSelector("input#Aorn");

    public EmailAccountNotFoundPage(ScenarioContext context, string email) : base(context)
    {
        VerifyPage(GovBody, email);

        VerifyPage(GovBody, $"We cannot find an account linked to");
    }

    public AddAnEmployerPage ContinueToInvite()
    {
        formCompletionHelper.EnterText(PayeSelector, eprDataHelper.EmployerPaye);

        formCompletionHelper.EnterText(AornSelector, eprDataHelper.EmployerAorn);

        Continue();

        return new(context);
    }
}
