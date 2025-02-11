namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class TermsAndConditionsPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Terms and conditions";

    private static By ConfirmAndContinueButton => By.Id("confirm-and-continue");

    public RequiresLineManagerApprovalPage AcceptTermsAndConditions()
    {
        formCompletionHelper.Click(ConfirmAndContinueButton);
        return new RequiresLineManagerApprovalPage(context);
    }
}



