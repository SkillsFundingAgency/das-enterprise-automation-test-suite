namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AddAstandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => pageTitle;

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
        return new ManageTheStandardsYouDeliverPage(context);
    }
}
