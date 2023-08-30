namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class TermsAndConditionsPage : AanBasePage
{
    protected override string PageTitle => "Terms and Conditions";

    private static By ConfirmAndContinueButton => By.Id("confirm-and-continue");

    public TermsAndConditionsPage(ScenarioContext context) : base(context) => VerifyPage();

    public RequiresLineManagerApprovalPage AcceptTermsAndConditions()
    {
        formCompletionHelper.Click(ConfirmAndContinueButton);
        return new RequiresLineManagerApprovalPage(context);
    }
}



