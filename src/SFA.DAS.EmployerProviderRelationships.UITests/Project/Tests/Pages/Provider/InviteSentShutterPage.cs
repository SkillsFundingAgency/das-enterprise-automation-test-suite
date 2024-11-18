namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class InviteSentShutterPage : ProviderRelationshipsBasePage
{
    private static By GovBody => By.CssSelector(".govuk-body");

    protected override string PageTitle => "Invitation sent";

    private static By EmplAccDetails => By.PartialLinkText("Employer account details");

    private static By InsetText => By.CssSelector("#main-content .govuk-inset-text");

    public InviteSentShutterPage(ScenarioContext context, bool verifyPayeandAorn) : base(context)
    {
        MultipleVerifyPage([() => VerifyPage(GovBody, "Your organisation has already invited"),() => VerifyPage(GovBody, eprDataHelper.EmployerEmail)]);
        
        if (verifyPayeandAorn)
        {
            MultipleVerifyPage([() => VerifyPage(InsetText, eprDataHelper.EmployerPaye), () => VerifyPage(InsetText, eprDataHelper.EmployerAorn)]);
        }
    }

    public EmployerAccountDetailsPage GoToEmpAccountDetails()
    {
        formCompletionHelper.Click(EmplAccDetails);

        return new EmployerAccountDetailsPage(context);
    }
}
