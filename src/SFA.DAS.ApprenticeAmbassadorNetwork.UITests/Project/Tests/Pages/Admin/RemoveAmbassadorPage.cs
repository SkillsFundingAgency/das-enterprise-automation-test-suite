namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class RemoveAmbassadorPage(ScenarioContext context) : SearchEventsBasePage(context)
{

    protected override string PageTitle => "Remove ambassador";
    private static By BreachOfConductRadio => By.Id("breachCodeOfConduct");
    private static By InactivityRadio => By.Id("inActivity");
    private static By YesCheckbox = By.Id("hasRemoveConfirmed");
    private static By CacnelLink = By.XPath("(//a[text()='Cancel'])");

    public MemberProfilePage SelectReasonsToRemoveAndCancelRemoval()
    {
        formCompletionHelper.SelectRadioOptionByLocator(BreachOfConductRadio);
        formCompletionHelper.SelectRadioOptionByLocator(InactivityRadio);
        formCompletionHelper.SelectCheckbox(YesCheckbox);
        formCompletionHelper.ClickElement(CacnelLink);
        return new MemberProfilePage(context);
    }

}
