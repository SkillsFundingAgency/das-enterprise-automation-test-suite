namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AreYouSureDeleteStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Are you sure you want to delete this standard?";

    private static By DeleteStandardButton => By.Id("DeleteStandard");
    public AreYouSureDeleteStandardPage(ScenarioContext context) : base(context) { }

    public ManageTheStandardsYouDeliverPage DeleteStandard()
    {
        formCompletionHelper.ClickElement(DeleteStandardButton);
        return new ManageTheStandardsYouDeliverPage(context);
    }
}
