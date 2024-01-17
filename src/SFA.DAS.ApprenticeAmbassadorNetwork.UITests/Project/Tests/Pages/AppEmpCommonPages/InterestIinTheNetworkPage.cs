namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class InterestIinTheNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your areas of interest as an ambassador";
    private static By ProjectManagementCheckBox => By.Id("FirstSectionInterests_4__IsSelected");
    public YourAmbassadorProfilePage SelectProjectManagementAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByLocator(ProjectManagementCheckBox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
}
