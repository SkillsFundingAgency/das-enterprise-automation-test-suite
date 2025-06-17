namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class InviteSentShutterPage : ProviderRelationshipsBasePage
{
    private static By GovBody => By.CssSelector(".govuk-body");

    protected override string PageTitle => "Invitation sent";

    private static By EmplAccDetails(string orgName) => By.LinkText($"Employer account details for {orgName.ToUpper()}");

    private static By InsetText => By.CssSelector("#main-content .govuk-inset-text");

    public InviteSentShutterPage(ScenarioContext context, bool verifyPayeandAorn) : base(context)
    {
        MultipleVerifyPage(
            [
              () => VerifyFromMultipleElements(GovBody, "Your organisation has already invited"),
              () => VerifyFromMultipleElements(GovBody, "Your organisation has already invited this employer to create an account or add you as a training provider."),
              () => !verifyPayeandAorn || VerifyPage(InsetText, eprDataHelper.EmployerPaye),
              () => !verifyPayeandAorn || VerifyPage(InsetText, eprDataHelper.EmployerAorn)
            ]);
    }

    public EmployerAccountDetailsPage GoToEmpAccountDetails()
    {
        formCompletionHelper.Click(EmplAccDetails(eprDataHelper.EmployerOrganisationName));

        return new EmployerAccountDetailsPage(context);
    }
}
