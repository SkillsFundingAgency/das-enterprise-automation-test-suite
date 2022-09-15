namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AddAstandard_ActuaryPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Actuary (Level 7)";

    private static By YesRadio => By.Id("is-correct-standard-yes");
    public AddAstandard_ActuaryPage(ScenarioContext context) : base(context) { }

    public YourContactInformationForThisStandardPage YesStandardIsCorrectAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
        Continue();
        return new YourContactInformationForThisStandardPage(context);
    }
    public ManageTheStandardsYouDeliverPage Save_NewStandard_Continue()
    {
        Continue();
        return new ManageTheStandardsYouDeliverPage(context);
    }
}
