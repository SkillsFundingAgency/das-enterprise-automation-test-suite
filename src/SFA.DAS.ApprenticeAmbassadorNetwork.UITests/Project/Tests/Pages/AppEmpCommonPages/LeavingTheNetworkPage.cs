namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class LeavingTheNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Leaving the network";

    private static By ExcellentRadioBox => By.Id("Excellent");
    private static By UnableToCommitCheckBox => By.Id("LeavingReasons_0__IsSelected");
    private static By ProfessionalCheckBox => By.Id("LeavingBenefits_0__IsSelected");

    public ConfirmLeaveTheNetworkPage CompleteFeedbackAboutLeavingAndContinue()
    {
        formCompletionHelper.SelectCheckbox(UnableToCommitCheckBox);
        formCompletionHelper.SelectRadioOptionByLocator(ExcellentRadioBox);
        formCompletionHelper.SelectCheckbox(ProfessionalCheckBox);
        Continue();
        return new ConfirmLeaveTheNetworkPage(context);
    }
}
