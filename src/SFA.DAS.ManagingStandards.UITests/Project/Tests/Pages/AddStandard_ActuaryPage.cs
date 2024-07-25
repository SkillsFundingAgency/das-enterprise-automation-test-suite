namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AddAstandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => pageTitle;
    protected override string AccessibilityPageTitle => "Add a standard page";

    private readonly string pageTitle;

    private static By YesRadio => By.CssSelector("#is-correct-standard-yes");

    public AddAstandardPage(ScenarioContext context, string standardname) : base(context, false)
    {
        pageTitle = standardname;

        VerifyPage();
    }

    public YourContactInformationForThisStandardPage YesStandardIsCorrectAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
        Continue();
        return new YourContactInformationForThisStandardPage(context);
    }
    public ManageTheStandardsYouDeliverPage Save_NewStandard_Continue()
    {
        Continue();

        try
        {
            VerifyPage(PageHeader, "Sorry, there is a problem with the service", null);
            var sorryThereIsAProblem = new SorryThereIsAProblem(context);
            sorryThereIsAProblem.ClickReturnToDashboard().AccessStandards();
        }
        catch (System.Exception)
        {

        }

        return new ManageTheStandardsYouDeliverPage(context);
    }
}
